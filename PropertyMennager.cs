namespace FormDesiner
{
    public class PropertyMennager
    {

        public class PropertyTypes
        {
            public class StringProperty : Iproperty
            {
                protected string Name { get; }
                public string Value { get; set; }

                public StringProperty(string name, string value)
                {
                    Name = name;
                    Value = value;
                }
                
                public string GiveLine()
                {
                    return Name+ " = " + '"'+Value+'"' + ";";
                }
                
                public void GiveValue(string value)
                {
                    Value = value;
                }
                
                public string GetName()
                {
                    return Name;
                }
            }
            
            public class IntProperty : Iproperty
            {
                protected string Name { get; }
                public int Value { get; set; }

                public IntProperty(string name, int value)
                {
                    Name = name;
                    Value = value;
                }
                
                public string GiveLine()
                {
                    return Name+ " = " + " + Value; ";
                }
                
                public void GiveValue(string value)
                {
                    Value = int.Parse(value);
                }
                
                public string GetName()
                {
                    return Name;
                }
            }
            
            public class BoolProperty : Iproperty
            {
                protected string Name { get; }
                public bool Value { get; set; }

                public BoolProperty(string name, bool value)
                {
                    Name = name;
                    Value = value;
                }
                
                public string GiveLine()
                {
                    return Name+ " = " + Value.ToString() + ";";
                }
                
                public void GiveValue(string value)
                {
                    if (value == "true")
                    {
                        Value = true;
                    }
                    else
                    {
                        Value = false;
                    }
                }
                
                public string GetName()
                {
                    return Name;
                }
            }

            public class DrawingPointProperty : Iproperty
            {
                public System.Drawing.Point Value { get; set; }
                protected string Name { get; }
                
                public DrawingPointProperty(string name, System.Drawing.Point value)
                {
                    Name = name;
                    Value = value;
                }
                
                public DrawingPointProperty(string name, int x, int y)
                {
                    Name = name;
                    Value = new System.Drawing.Point(x, y);
                }
                
                public string GiveLine()
                {
                    return Name+ " = " + "new System.Drawing.Point(" + Value.X + ", " + Value.Y + ");";
                }
                
                public void GiveValue(string value)
                {
                    string point1 = value.Substring(0, value.IndexOf(','));
                    string point2 = value.Substring(value.IndexOf(',') + 1, value.Length - value.IndexOf(',') - 2);
                    Value = new System.Drawing.Point(int.Parse(point1), int.Parse(point2));
                }
                
                public string GetName()
                {
                    return Name;
                }
            }
            
            public class DrawingSizeProperty : Iproperty
            {
                public System.Drawing.Size Value { get; set; }
                protected string Name { get; }
                
                public DrawingSizeProperty(string name, System.Drawing.Size value)
                {
                    Name = name;
                    Value = value;
                }
                
                public DrawingSizeProperty(string name, int x, int y)
                {
                    Name = name;
                    Value = new System.Drawing.Size(x, y);
                }
                
                public string GiveLine()
                {
                    return Name+ " = " + "new System.Drawing.Size(" + Value.Width + ", " + Value.Height + ");";
                }
                
                public void GiveValue(string value)
                {
                    string point1 = value.Substring(0, value.IndexOf(','));
                    string point2 = value.Substring(value.IndexOf(',') + 1, value.Length - value.IndexOf(',') - 2);
                    Value = new System.Drawing.Size(int.Parse(point1), int.Parse(point2));
                }
                
                public string GetName()
                {
                    return Name;
                }
            }
            
            public class DrawingSizeFProperty : Iproperty
            {
                public System.Drawing.SizeF Value { get; set; }
                protected string Name { get; }
                
                public DrawingSizeFProperty(string name, System.Drawing.SizeF value)
                {
                    Name = name;
                    Value = value;
                }
                
                public DrawingSizeFProperty(string name, float x, float y)
                {
                    Name = name;
                    Value = new System.Drawing.SizeF(x, y);
                }
                
                public string GiveLine()
                {
                    return Name+ " = " + "new System.Drawing.SizeF(" + Value.Width + ", " + Value.Height + ");";
                }
                
                public void GiveValue(string value)
                {
                    string point1 = value.Substring(0, value.IndexOf(','));
                    string point2 = value.Substring(value.IndexOf(',') + 1, value.Length - value.IndexOf(',') - 2);
                    Value = new System.Drawing.SizeF(float.Parse(point1), float.Parse(point2));
                }
                
                public string GetName()
                {
                    return Name;
                }
            }
        }
        
        #region Properties
        public class AutoSizeProperty : PropertyTypes.BoolProperty
        {
            public AutoSizeProperty(bool value) : base("AutoSize", value)
            {
            }
        }
        
        public class LocationProperty : PropertyTypes.DrawingPointProperty
        {
            public LocationProperty(System.Drawing.Point value) : base("Location", value)
            {
            }
            
            public LocationProperty(int x, int y) : base("Location", x, y)
            {
            }
        }
        
        public class NameProperty : PropertyTypes.StringProperty
        {
            public NameProperty(string value) : base("Name", value)
            {
            }
        }
        
        public class SizeProperty : PropertyTypes.DrawingSizeProperty
        {
            public SizeProperty(System.Drawing.Size value) : base("Size", value)
            {
            }
            
            public SizeProperty(int x, int y) : base("Size", x, y)
            {
            }
        }
        
        public class TabIndexProperty : PropertyTypes.IntProperty
        {
            public TabIndexProperty(int value) : base("TabIndex", value)
            {
            }
        }
        
        public class TextProperty : PropertyTypes.StringProperty
        {
            public TextProperty(string value) : base("Text", value)
            {
            }
        }
        
        public class UseVisualStyleBackColorProperty : PropertyTypes.BoolProperty
        {
            public UseVisualStyleBackColorProperty(bool value) : base("UseVisualStyleBackColor", value)
            {
            }
        }
        
        public class FormattingEnabledProperty : PropertyTypes.BoolProperty
        {
            public FormattingEnabledProperty(bool value) : base("FormattingEnabled", value)
            {
            }
        }
        
        #endregion
        
    }
    
    public interface Iproperty
    {
        string GiveLine();
        void GiveValue(string val);
        string GetName();
         
    }
}