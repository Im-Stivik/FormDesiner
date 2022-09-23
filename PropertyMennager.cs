using System.Windows.Forms;

namespace FormDesiner
{
    public class PropertyMennager
    {
        public enum DataTypes
        {
            String,
            Int,
            Double,
            Boolean,
            DateTime,
            Image,
            Color,
            Font,
            Point,
            Size,
            Rectangle,
            Enum,
            Object
        }

        public enum PropertyNames
        {
            AutoSize,
            Location,
            Name,
            Size,
            TabIndex,
            Text,
            AccessibleDescription,
            AccessibleName,
            AccessibleRole,
            BackColor,
            Font,
        }

        public static Propertyes GetDataTypeByPropertyName(PropertyNames propertyName)
        {
            //TODO:: implement this method
            return null;
        }
        
        public class Property
        {
            public PropertyNames Name { get; }
            public object Value { get; set; }
            public DataTypes Type { get; }
            public Property(PropertyNames name, object value, DataTypes type)
            {
                Name = name;
                Value = value;
                Type = type;
            }

            public virtual string GetLine()
            {
                return Name + " = " + Value + ";";
            }
        }

        public class Propertyes
        {
            public class AutoSizeProperty : Property
            {
                public AutoSizeProperty(bool value) : base(PropertyNames.AutoSize, value, DataTypes.Boolean)
                {
                }
                
                public override string GetLine()
                {
                    return "AutoSize = " + Value.ToString().ToLower() + ";";
                }
            }
            
            public class LocationProperty : Property
            {
                public LocationProperty(System.Drawing.Point value) : base(PropertyNames.Location, value,
                    DataTypes.Point)
                {
                }

                public override string GetLine()
                {
                    System.Drawing.Point value = (System.Drawing.Point) Value;
                    return Name + " = new System.Drawing.Point(" + value.X + ", " + value.Y + ");";
                }
            }
            
            public class NameProperty : Property
            {
                public NameProperty(string value) : base(PropertyNames.Name,
                    value, DataTypes.String)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = \"" + Value + "\";";
                }
            }
            
            public class SizeProperty : Property
            {
                public SizeProperty(System.Drawing.Size value) : base(PropertyNames.Size, value, 
                    DataTypes.Size)
                {
                }

                public override string GetLine()
                {
                    System.Drawing.Size value = (System.Drawing.Size) Value;
                    return Name + " = new System.Drawing.Size(" + value.Width + ", " + value.Height + ");";
                }
            }
            
            public class TabIndexProperty : Property
            {
                public TabIndexProperty(int value) : base(PropertyNames.TabIndex, value, DataTypes.Int)
                {
                }
            }
            
            public class TextProperty : Property
            {
                public TextProperty(string value) : base(PropertyNames.Text, value, DataTypes.String)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = \"" + Value + "\";";
                }
            }
            
            public class AccessibleDescriptionProperty : Property
            {
                public AccessibleDescriptionProperty(string value) : base(PropertyNames.AccessibleDescription, 
                    value, DataTypes.String)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = \"" + Value + "\";";
                }
            }
            
            public class AccessibleNameProperty : Property
            {
                public AccessibleNameProperty(string value) : base(PropertyNames.AccessibleName, 
                    value, DataTypes.String)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = \"" + Value + "\";";
                }
            }
            
            public class AccessibleRoleProperty : Property
            {
                public AccessibleRoleProperty(AccessibleRole value) : base(PropertyNames.AccessibleRole, 
                    value, DataTypes.Enum)
                {
                }
            }
            
            public class BackColorProperty : Property
            {
                public BackColorProperty(System.Drawing.Color value) : base(PropertyNames.BackColor, 
                    value, DataTypes.Color)
                {
                }
                
                //TODO: implement 3 types of color
                public override string GetLine()
                {
                    System.Drawing.Color value = (System.Drawing.Color) Value;
                    return Name + " = Color.FromArgb(" + value.A + ", " + value.R + ", " + value.G + ", " + value.B + ");";
                }
            }
            
            public class FontProperty : Property
            {
                public FontProperty(System.Drawing.Font value) : base(PropertyNames.Font, 
                    value, DataTypes.Font)
                {
                }
                
                public override string GetLine()
                {
                    System.Drawing.Font value = (System.Drawing.Font) Value;
                    return Name + " = new Font(\"" + value.Name + "\", " + value.Size + ", " + value.Style + ");";
                }
            }
            
            
        }
    }
}