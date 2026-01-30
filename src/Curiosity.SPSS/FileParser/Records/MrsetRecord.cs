using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Curiosity.SPSS.SpssDataset;

namespace Curiosity.SPSS.FileParser.Records
{
    public class MrsetRecord : BaseInfoRecord
    {
        public override int SubType => InfoRecordType.MultipleResponseSets;

        private byte[] Data { get; set; }
        
        public MrsetRecord(Encoding encoding, Mrset mrset)
        {
            Encoding = encoding;
            Data = BuildMrset(mrset, Encoding);
            ItemCount = Data.Length;
            ItemSize = 1;
        } 
        
        protected override void WriteInfo(BinaryWriter writer)
        {
            writer.Write(Data);
        }

        protected override void FillInfo(BinaryReader reader)
        {
            
        }

        private static byte[] BuildMrset(Mrset mrset, Encoding encoding)
        {
            var data = new List<byte>();
            var spaceBytes = encoding.GetBytes(" ");

            data.AddRange(encoding.GetBytes($"${mrset.Name}"));
            data.AddRange(encoding.GetBytes("="));
            
            
            switch (mrset.MrsetType)
            {
                case MrsetType.Category:
                    data.AddRange(encoding.GetBytes("C"));
                    data.AddRange(spaceBytes);
                    break;
                case MrsetType.Dichotomy when mrset.CategoryLabelsSource == CategoryLabelsSources.VariableLabels:
                    data.AddRange(encoding.GetBytes("D"));
                    var countedValueLength = encoding.GetBytes(mrset.CountedValue.ToString().Length.ToString());
                    data.AddRange(countedValueLength);
                    data.AddRange(spaceBytes);
                    data.AddRange(encoding.GetBytes(mrset.CountedValue.ToString()));
                    data.AddRange(spaceBytes);

                    break;
                case MrsetType.Dichotomy when mrset.CategoryLabelsSource == CategoryLabelsSources.LabelsOfCountedValue:
                    throw new NotImplementedException("Is not implemented in the current version of SPSSlib");
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            
            var label = encoding.GetBytes(mrset.Label);
            data.AddRange(encoding.GetBytes(label.Length.ToString()));
            data.AddRange(spaceBytes);
            data.AddRange(label);
            
            data.AddRange(spaceBytes);
            data.AddRange(encoding.GetBytes(string.Join(" ", mrset.Variables.Select(x => x.Name))));
            data.Add(0x0a);
            
            return data.ToArray();
        }
    }
}