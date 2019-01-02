using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePluSight.Models
{

    public class Deputy
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>

        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class milletvekili
        {

            private string titleField;

            private string languageField;

            private string copyrightField;

            private milletvekiliAday[] adayField;

            /// <remarks/>
            public string title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            public string language
            {
                get
                {
                    return this.languageField;
                }
                set
                {
                    this.languageField = value;
                }
            }

            /// <remarks/>
            public string copyright
            {
                get
                {
                    return this.copyrightField;
                }
                set
                {
                    this.copyrightField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("aday")]
            public milletvekiliAday[] aday
            {
                get
                {
                    return this.adayField;
                }
                set
                {
                    this.adayField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [BsonIgnoreExtraElements(true)]

        public partial class milletvekiliAday
        {

            private string secim_bolgesiField;

            private ushort bolge_idField;

            private string siyasi_partiField;

            private byte parti_idField;

            private string siraField;

            private string unvanField;

            private string ad_soyadField;

            private string meslekField;

            private string dogum_yeriField;

            private string dogum_tarihiField;

            private string cinsiyetField;

            private string fotografField;

            private string ozgecmisField;

            /// <remarks/>
            public string secim_bolgesi
            {
                get
                {
                    return this.secim_bolgesiField;
                }
                set
                {
                    this.secim_bolgesiField = value;
                }
            }

            /// <remarks/>
            public ushort bolge_id
            {
                get
                {
                    return this.bolge_idField;
                }
                set
                {
                    this.bolge_idField = value;
                }
            }

            /// <remarks/>
            public string siyasi_parti
            {
                get
                {
                    return this.siyasi_partiField;
                }
                set
                {
                    this.siyasi_partiField = value;
                }
            }

            /// <remarks/>
            public byte parti_id
            {
                get
                {
                    return this.parti_idField;
                }
                set
                {
                    this.parti_idField = value;
                }
            }

            /// <remarks/>
            public string sira
            {
                get
                {
                    return this.siraField;
                }
                set
                {
                    this.siraField = value;
                }
            }

            /// <remarks/>
            public string unvan
            {
                get
                {
                    return this.unvanField;
                }
                set
                {
                    this.unvanField = value;
                }
            }

            /// <remarks/>
            public string ad_soyad
            {
                get
                {
                    return this.ad_soyadField;
                }
                set
                {
                    this.ad_soyadField = value;
                }
            }

            /// <remarks/>
            public string meslek
            {
                get
                {
                    return this.meslekField;
                }
                set
                {
                    this.meslekField = value;
                }
            }

            /// <remarks/>
            public string dogum_yeri
            {
                get
                {
                    return this.dogum_yeriField;
                }
                set
                {
                    this.dogum_yeriField = value;
                }
            }

            /// <remarks/>
            public string dogum_tarihi
            {
                get
                {
                    return this.dogum_tarihiField;
                }
                set
                {
                    this.dogum_tarihiField = value;
                }
            }

            /// <remarks/>
            public string cinsiyet
            {
                get
                {
                    return this.cinsiyetField;
                }
                set
                {
                    this.cinsiyetField = value;
                }
            }

            /// <remarks/>
            public string fotograf
            {
                get
                {
                    return this.fotografField;
                }
                set
                {
                    this.fotografField = value;
                }
            }

            /// <remarks/>
            public string ozgecmis
            {
                get
                {
                    return this.ozgecmisField;
                }
                set
                {
                    this.ozgecmisField = value;
                }
            }
        }


    }
}
