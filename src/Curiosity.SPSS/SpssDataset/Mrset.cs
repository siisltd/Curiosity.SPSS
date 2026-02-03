using System;
using System.Collections.Generic;
using System.Linq;
using Curiosity.SPSS.FileParser.Records;

namespace Curiosity.SPSS.SpssDataset
{
    public class Mrset
    {
        private readonly Variable[] _variables;
        
        internal MrsetType MrsetType { get; private set; } = MrsetType.Category;
        
        internal CategoryLabelsSources CategoryLabelsSource { get; private set; }
        
        internal bool UseVariableLabelAsSetLabel {get; private set;}
        
        public string Name { get; private set; }
        public string Label { get; private set; }
        
        public int CountedValue { get; private set; }
        
        public IReadOnlyCollection<Variable> Variables => _variables;
        
        
        public Mrset(
            string name,
            string label,
            IEnumerable<Variable> variables)
        {
            if (variables == null) throw new ArgumentNullException(nameof(variables));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Label = label ?? throw new ArgumentNullException(nameof(label));
            
            _variables = variables.ToArray();
            if (_variables.Length == 0)
            {
                throw new ArgumentException("Variables cannot be empty", nameof(variables));
            }
        }

        public void SetLabelsOfCountedValue_LabelsSource(int countedValue, bool useVariableLabelAsSetLabel)
        {
            throw new NotImplementedException("Is not implemented in the current version of SPSSlib");
            // TODO implement may be?
            //MrsetType = MrsetType.Dichotomy;
            //CategoryLabelsSource = CategoryLabelsSources.LabelsOfCountedValue;
            //UseVariableLabelAsSetLabel = useVariableLabelAsSetLabel;
            //CountedValue = countedValue;
        }
        
        public void SetVariableLabels_LabelsSource(int countedValue)
        {
            MrsetType = MrsetType.Dichotomy;
            CategoryLabelsSource = CategoryLabelsSources.VariableLabels;
            UseVariableLabelAsSetLabel = false;
            CountedValue = countedValue;
        }
    }
}