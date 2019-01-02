using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Models
{
    public class Election
    {



        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Person
        {

            private string nameField;

            private System.DateTime dateOfBirthField;

            private PersonAddress addressField;

            private PersonCar[] carField;

            /// <remarks/>
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime DateOfBirth
            {
                get
                {
                    return this.dateOfBirthField;
                }
                set
                {
                    this.dateOfBirthField = value;
                }
            }

            /// <remarks/>
            public PersonAddress Address
            {
                get
                {
                    return this.addressField;
                }
                set
                {
                    this.addressField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Car")]
            public PersonCar[] Car
            {
                get
                {
                    return this.carField;
                }
                set
                {
                    this.carField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class PersonAddress
        {

            private byte houseNoField;

            private string postCodeField;

            /// <remarks/>
            public byte HouseNo
            {
                get
                {
                    return this.houseNoField;
                }
                set
                {
                    this.houseNoField = value;
                }
            }

            /// <remarks/>
            public string PostCode
            {
                get
                {
                    return this.postCodeField;
                }
                set
                {
                    this.postCodeField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class PersonCar
        {

            private string makeField;

            private string modelField;

            /// <remarks/>
            public string Make
            {
                get
                {
                    return this.makeField;
                }
                set
                {
                    this.makeField = value;
                }
            }

            /// <remarks/>
            public string Model
            {
                get
                {
                    return this.modelField;
                }
                set
                {
                    this.modelField = value;
                }
            }
        }



    }
}
