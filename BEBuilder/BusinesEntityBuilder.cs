using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BEBuilder
{
    public class BusinesEntityBuilder<T>
    {
        public T Construct(IDataReader drReader)
        {
            T objBE = Activator.CreateInstance<T>();
            foreach(var prop in typeof(T).GetProperties()){
                var attrColum = (ColumnAttribute)prop.GetCustomAttribute(typeof(ColumnAttribute));
                var indexColum = drReader.GetOrdinal(attrColum.Name);
                if (!drReader.IsDBNull(indexColum))
                {
                    prop.SetValue(objBE, this.ConverTo(prop.PropertyType, drReader.GetValue(indexColum)));
                }
            }   
            return objBE;
        }

        public List<T> ConstructList(IDataReader reader)
        {
            List<T> listBE = new List<T>();
            while (reader.Read())
            {
                listBE.Add(Construct(reader));
            }
            return listBE;
        }

        public object ConverTo(Type typeTarget,object valueToConvert) {
            object ret = null;
            if (typeTarget == typeof(Boolean)) {
                ret = (valueToConvert.Equals(1));
            }else if(typeTarget == typeof(String)){
                ret = valueToConvert;
            }
            else if (typeTarget == typeof(Int32))
            {
                ret = Convert.ToInt32(valueToConvert);
            }
            else if (typeTarget == typeof(Int64))
            {
                ret = Convert.ToInt64(valueToConvert);
            }
            else if (typeTarget == typeof(DateTime))
            {
                ret = Convert.ToDateTime(valueToConvert);
            }
            else if (typeTarget == typeof(Decimal))
            {
                ret = Convert.ToDecimal(valueToConvert);
            }
            else if (typeTarget == typeof(Double))
            {
                ret = Convert.ToDouble(valueToConvert);
            }
            else {
                ret = valueToConvert.ToString();
            }
            
            return ret;
        }
    }
}
