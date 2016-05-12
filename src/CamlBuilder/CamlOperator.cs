﻿namespace CamlBuilder
{
    using System;
    using Internal;

    /// <summary>
    /// Defines a CAML operator. This is an abstract class. To instanciate an operator use public static methods.
    /// </summary>
    public abstract class CamlOperator : CamlStatement
    {
        internal readonly string OperatorTypeString;

        /// <summary>
        /// Gets the operator type. 
        /// </summary>
        public CamlOperatorType OperatorType { get; } 

        /// <summary>
        /// Gets the name of the field on which this operator acts on.
        /// </summary>
        public string FieldName { get; private set; }

        protected internal CamlOperator(CamlOperatorType operatorType, string fieldName)
        {
            OperatorType = operatorType;
            FieldName = fieldName;

            switch (operatorType)
            {
                case CamlOperatorType.Equal:
                    OperatorTypeString = "Eq";
                    break;
                case CamlOperatorType.NotEqual:
                    OperatorTypeString = "Neq";
                    break;
                case CamlOperatorType.GreaterThan:
                    OperatorTypeString = "Gt";
                    break;
                case CamlOperatorType.GreaterThanOrEqualTo:
                    OperatorTypeString = "Geq";
                    break;
                case CamlOperatorType.LowerThan:
                    OperatorTypeString = "Lt";
                    break;
                case CamlOperatorType.LowerThanOrEqualTo:
                    OperatorTypeString = "Leq";
                    break;
                case CamlOperatorType.IsNull:
                case CamlOperatorType.IsNotNull:
                case CamlOperatorType.BeginsWith:
                case CamlOperatorType.Contains:
                case CamlOperatorType.DateRangesOverlap:
                case CamlOperatorType.Includes:
                case CamlOperatorType.NotIncludes:
                    OperatorTypeString = operatorType.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(operatorType), operatorType, null);
            }
        }

        /// <summary>
        /// Instanciates a new <i>IsNull</i> operator to perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <returns>IsNull operator instance.</returns>
        public static CamlOperator IsNull(string fieldName)
        {
            return new CamlSimpleOperator(CamlOperatorType.IsNull, fieldName);
        }

        /// <summary>
        /// Instanciates a new <i>IsNotNull</i> operator to perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <returns>IsNotNull operator instance.</returns>
        public static CamlOperator IsNotNull(string fieldName)
        {
            return new CamlSimpleOperator(CamlOperatorType.IsNotNull, fieldName);
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static CamlOperator Equal(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.Equal, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Equal</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Equal operator instance.</returns>
        public static CamlOperator Equal(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.Equal, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static CamlOperator NotEqual(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.NotEqual, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>NotEqual</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotEqual operator instance.</returns>
        public static CamlOperator NotEqual(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.NotEqual, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static CamlOperator BeginsWith(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.BeginsWith, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>BeginsWith</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>BeginsWith operator instance.</returns>
        public static CamlOperator BeginsWith(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.BeginsWith, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static CamlOperator Contains(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.Contains, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Contains</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Contains operator instance.</returns>
        public static CamlOperator Contains(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.Contains, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static CamlOperator DateRangesOverlap(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.DateRangesOverlap, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>DateRangesOverlap</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>DateRangesOverlap operator instance.</returns>
        public static CamlOperator DateRangesOverlap(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.DateRangesOverlap, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static CamlOperator GreaterThan(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.GreaterThan, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThan</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThan operator instance.</returns>
        public static CamlOperator GreaterThan(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.GreaterThan, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static CamlOperator GreaterThanOrEqualTo(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.GreaterThanOrEqualTo, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>GreaterThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>GreaterThanOrEqualTo operator instance.</returns>
        public static CamlOperator GreaterThanOrEqualTo(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.GreaterThanOrEqualTo, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static CamlOperator LowerThan(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.LowerThan, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>LowerThan</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThan operator instance.</returns>
        public static CamlOperator LowerThan(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.LowerThan, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static CamlOperator LowerThanOrEqualTo(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.LowerThanOrEqualTo, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>LowerThanOrEqualTo</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>LowerThanOrEqualTo operator instance.</returns>
        public static CamlOperator LowerThanOrEqualTo(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.LowerThanOrEqualTo, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static CamlOperator Includes(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.Includes, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>Includes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>Includes operator instance.</returns>
        public static CamlOperator Includes(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.Includes, fieldName, value);
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="valueType">Field type</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static CamlOperator NotIncludes(string fieldName, CamlValueType valueType, object value)
        {
            return new CamlComplexOperator(CamlOperatorType.NotIncludes, fieldName, CamlValue.Value(valueType, value));
        }

        /// <summary>
        /// Instanciates a new <i>NotIncludes</i> operator which will perform on specified <paramref name="fieldName"/>.
        /// </summary>
        /// <param name="fieldName">Name of the field to operate on.</param>
        /// <param name="value">Value against which the value returned by the field element is compared to.</param>
        /// <returns>NotIncludes operator instance.</returns>
        public static CamlOperator NotIncludes(string fieldName, CamlValue value)
        {
            return new CamlComplexOperator(CamlOperatorType.NotIncludes, fieldName, value);
        }
    }
}
