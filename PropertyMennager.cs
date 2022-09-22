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
        
        public class Property<T>
        {
            public PropertyNames Name { get; }
            public T Value { get; set; }
            public DataTypes Type { get; }
            public Property(PropertyNames name, T value, DataTypes type)
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
            public class AutoSizeProperty : Property<bool>
            {
                public AutoSizeProperty(bool value) : base(PropertyNames.AutoSize, value, DataTypes.Boolean)
                {
                }
            }
            
            public class LocationProperty : Property<System.Drawing.Point>
            {
                public LocationProperty(System.Drawing.Point value) : base(PropertyNames.Location, value,
                    DataTypes.Point)
                {
                }

                public override string GetLine()
                {
                    return Name + " = new Point(" + Value.X + ", " + Value.Y + ");";
                }
            }
            
            public class NameProperty : Property<string>
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
            
            public class SizeProperty : Property<System.Drawing.Size>
            {
                public SizeProperty(System.Drawing.Size value) : base(PropertyNames.Size, value, 
                    DataTypes.Size)
                {
                }

                public override string GetLine()
                {
                    return Name + " = new Size(" + Value.Width + ", " + Value.Height + ");";
                }
            }
            
            public class TabIndexProperty : Property<int>
            {
                public TabIndexProperty(int value) : base(PropertyNames.TabIndex, value, DataTypes.Int)
                {
                }
            }
            
            public class TextProperty : Property<string>
            {
                public TextProperty(string value) : base(PropertyNames.Text, value, DataTypes.String)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = \"" + Value + "\";";
                }
            }
            
            public class AccessibleDescriptionProperty : Property<string>
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
            
            public class AccessibleNameProperty : Property<string>
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
            
            public class AccessibleRoleProperty : Property<AccessibleRole>
            {
                public AccessibleRoleProperty(AccessibleRole value) : base(PropertyNames.AccessibleRole, 
                    value, DataTypes.Enum)
                {
                }
            }
            
            public class BackColorProperty : Property<System.Drawing.Color>
            {
                public BackColorProperty(System.Drawing.Color value) : base(PropertyNames.BackColor, 
                    value, DataTypes.Color)
                {
                }
                
                //TODO: implement 3 types of color
                public override string GetLine()
                {
                    return Name + " = Color.FromArgb(" + Value.A + ", " + Value.R + ", " + Value.G + ", " + Value.B + ");";
                }
            }
            
            public class FontProperty : Property<System.Drawing.Font>
            {
                public FontProperty(System.Drawing.Font value) : base(PropertyNames.Font, 
                    value, DataTypes.Font)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = new Font(\"" + Value.Name + "\", " + Value.Size + ", " + Value.Style + ");";
                }
            }
            
            
        }
    }
}