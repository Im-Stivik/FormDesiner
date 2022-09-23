using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using System.Security.Principal;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FormDesiner
{
    public class ItemMennager
    {
        public abstract class Item
        {
            public Control ControlItem { get;}
            public PropertyMennager.PropertyNames[] availableProperties { get; }
            public Dictionary<PropertyMennager.PropertyNames,PropertyMennager.Property> Properties { get; }
            

            public Item(Control controlItem, PropertyMennager.PropertyNames[] availableProperties)
            {
                ControlItem = controlItem;
                this.availableProperties = availableProperties;
                Properties = new Dictionary<PropertyMennager.PropertyNames, PropertyMennager.Property>();
                foreach (var propertyName in availableProperties)
                {
                    Properties.Add(propertyName, null);
                } 
            }
            
            public string GetName()
            {
                return Properties[PropertyMennager.PropertyNames.Name].Value.ToString();
            }
            
            public string PrintProperties()
            {
                string result = "//\n" + GetName() + "\n" + "//\n";
                foreach (var property in this.Properties)
                {
                    result += "this." + GetName()+ "." + property.Value.GetLine() + "\n";
                }
                
                return result;
            }
            
        }

        public class Items
        {
            public class Lable : Item
            {
                //TODO:: add properties
                public static PropertyMennager.PropertyNames[] availableProperties =
                    new PropertyMennager.PropertyNames[]
                    {
                        PropertyMennager.PropertyNames.AutoSize, PropertyMennager.PropertyNames.Location,
                        PropertyMennager.PropertyNames.Name, PropertyMennager.PropertyNames.Size,
                        PropertyMennager.PropertyNames.TabIndex, PropertyMennager.PropertyNames.Text
                    };
                public Lable(PropertyMennager.Propertyes.AutoSizeProperty autoSizeProperty, PropertyMennager.Propertyes.LocationProperty locationProperty, PropertyMennager.Propertyes.NameProperty nameProperty, PropertyMennager.Propertyes.SizeProperty sizeProperty, PropertyMennager.Propertyes.TabIndexProperty tabIndexProperty, PropertyMennager.Propertyes.TextProperty textProperty) : base(new Label(),availableProperties)
                {
                    //add all the properties to the list
                    Properties[PropertyMennager.PropertyNames.AutoSize]= autoSizeProperty;
                    Properties[PropertyMennager.PropertyNames.Location] = locationProperty;
                    Properties[PropertyMennager.PropertyNames.Name] = nameProperty;
                    Properties[PropertyMennager.PropertyNames.Size] = sizeProperty;
                    Properties[PropertyMennager.PropertyNames.TabIndex] = tabIndexProperty;
                    Properties[PropertyMennager.PropertyNames.Text] = textProperty;
                }
            }
        }
        }
    }
    