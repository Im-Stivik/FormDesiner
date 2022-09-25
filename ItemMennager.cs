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
        public enum ItemNames
        {
            Lable,
            TextBox,
        }
        
        public abstract class Item
        {
            public Control ControlItem { get;}
            public PropertyMennager.PropertyNames[] availableProperties { get; }
            public Dictionary<PropertyMennager.PropertyNames,PropertyMennager.Property> Properties { get; }
            
            public ItemNames Names { get; }

            public Item(ItemNames name,Control controlItem, PropertyMennager.PropertyNames[] availableProperties, PropertyMennager.Propertyes.ModifiersProperty modifiersProperty)
            {
                ControlItem = controlItem;
                this.availableProperties = availableProperties;
                Properties = new Dictionary<PropertyMennager.PropertyNames, PropertyMennager.Property>();
                foreach (var item in availableProperties)
                {
                    Properties.Add(item, null);
                }

                Properties[PropertyMennager.PropertyNames.Modifiers] = modifiersProperty;
                this.Names = name;
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
                    //we cant print the modifiers property and null properties
                    if(property.Value != null && property.Key != PropertyMennager.PropertyNames.Modifiers)
                        result += "this." + GetName()+ "." + property.Value.GetLine() + "\n";
                }
                
                return result;
            }

            public string PrintEnd()
            {
                string result = "";
                result += this.Properties[PropertyMennager.PropertyNames.Modifiers].GetLine() + " " + this.GetSource() +
                          this.GetName() + ":";

                return result;
            }

            public virtual string GetSource()
            {
                return "System.Windows.Forms." + this.Names.ToString();
            }
            
            public void AddProperty(PropertyMennager.Property property)
            {
                if (Properties.ContainsKey(property.Name))
                {
                    Properties[property.Name] = property;
                }
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
                        PropertyMennager.PropertyNames.AccessibleDescription, PropertyMennager.PropertyNames.AccessibleName,
                        PropertyMennager.PropertyNames.AccessibleRole, PropertyMennager.PropertyNames.BackColor,
                        PropertyMennager.PropertyNames.BorderStyle, PropertyMennager.PropertyNames.Cursor,
                        PropertyMennager.PropertyNames.FlatStyle, PropertyMennager.PropertyNames.Font,
                        PropertyMennager.PropertyNames.ForeColor,PropertyMennager.PropertyNames.Image,
                        PropertyMennager.PropertyNames.ImageAlign, PropertyMennager.PropertyNames.ImageIndex,
                        PropertyMennager.PropertyNames.ImageKey, PropertyMennager.PropertyNames.ImageList,
                        PropertyMennager.PropertyNames.RightToLeft, PropertyMennager.PropertyNames.Text,
                        PropertyMennager.PropertyNames.TextAlign, PropertyMennager.PropertyNames.UseMnemonic,
                        PropertyMennager.PropertyNames.UseWaitCursor, PropertyMennager.PropertyNames.AllowDrop,
                        PropertyMennager.PropertyNames.AutoEllipsis,
                        PropertyMennager.PropertyNames.ContextMenuStrip, PropertyMennager.PropertyNames.Enabled,
                        PropertyMennager.PropertyNames.TabIndex, PropertyMennager.PropertyNames.UseCompatibleTextRendering,
                        PropertyMennager.PropertyNames.Visible, PropertyMennager.PropertyNames.ApplicationSettings,
                        PropertyMennager.PropertyNames.DataBindings, PropertyMennager.PropertyNames.Tag,
                        PropertyMennager.PropertyNames.Name, PropertyMennager.PropertyNames.GenerateMember,
                        PropertyMennager.PropertyNames.Locked, PropertyMennager.PropertyNames.Modifiers,
                        PropertyMennager.PropertyNames.CausesValidation, PropertyMennager.PropertyNames.Anchor,
                        PropertyMennager.PropertyNames.AutoSize, PropertyMennager.PropertyNames.Dock,
                        PropertyMennager.PropertyNames.Location,PropertyMennager.PropertyNames.Margin,
                        PropertyMennager.PropertyNames.MaximumSize, PropertyMennager.PropertyNames.MinimumSize
                    };
                public Lable(PropertyMennager.Propertyes.AutoSizeProperty autoSizeProperty, PropertyMennager.Propertyes.LocationProperty locationProperty, PropertyMennager.Propertyes.NameProperty nameProperty, PropertyMennager.Propertyes.SizeProperty sizeProperty, PropertyMennager.Propertyes.TabIndexProperty tabIndexProperty, PropertyMennager.Propertyes.TextProperty textProperty, PropertyMennager.Propertyes.ModifiersProperty modifiersProperty) : base(ItemNames.Lable,new Label(),availableProperties,modifiersProperty)
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
    