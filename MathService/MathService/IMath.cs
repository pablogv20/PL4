using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace MathService
{
    [ServiceContract]
    public interface IMath
    {
        [OperationContract]
        bool Prime(int value);

        [OperationContract]
        Tuple Add(Tuple tuple);

        [OperationContract]
        double[] SolveLinearSystem(int numEquations, double[][] coefficients, double[] constants);

    }

    // Definición del tipo de datos Tuple
    [DataContract]
    public class Tuple
    {
        double[] _data;
        string _name;

        [DataMember]
        public double[] Data
        {
            get { return _data; }
            set { _data = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}