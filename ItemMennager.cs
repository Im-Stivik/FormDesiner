using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;

namespace FormDesiner
{
    public class ItemMennager
    {
        
        
        #region items

        public class Button : Item
        {
            
            
            public Button(PropertyMennager.LocationProperty location, PropertyMennager.NameProperty name,
                PropertyMennager.SizeProperty size, PropertyMennager.TabIndexProperty tabIndex,
                PropertyMennager.TextProperty text,
                PropertyMennager.UseVisualStyleBackColorProperty useVisualStyleBackColor)
            {
                PropertyMennager.AutoSizeProperty autoSize = new PropertyMennager.AutoSizeProperty(true);
                properties.Add(autoSize);
                properties.Add(location);
                properties.Add(name);
                properties.Add(size);
                properties.Add(tabIndex);
                properties.Add(text);
                properties.Add(useVisualStyleBackColor);
                this._name = name.Value;
            }

            public override string GetSource()
            {
                return "private System.Windows.Forms.Button " + _name + ";";
            }
        }
        
        public class CheckBox : Item
        {
            public CheckBox(PropertyMennager.LocationProperty location, PropertyMennager.NameProperty name,
                PropertyMennager.SizeProperty size, PropertyMennager.TabIndexProperty tabIndex,
                PropertyMennager.TextProperty text,
                PropertyMennager.UseVisualStyleBackColorProperty useVisualStyleBackColor)
            {
                PropertyMennager.AutoSizeProperty autoSize = new PropertyMennager.AutoSizeProperty(true);
                properties.Add(autoSize);
                properties.Add(location);
                properties.Add(name);
                properties.Add(size);
                properties.Add(tabIndex);
                properties.Add(text);
                properties.Add(useVisualStyleBackColor);
                this._name = name.Value;
            }
            
            public override string GetSource()
            {
                return "private System.Windows.Forms.CheckBox " + _name + ";";
            }
        }

        public class CheckedListBox : Item
        {
            public CheckedListBox(PropertyMennager.LocationProperty location, PropertyMennager.NameProperty name,
                PropertyMennager.SizeProperty size, PropertyMennager.TabIndexProperty tabIndex)
            {
                PropertyMennager.FormattingEnabledProperty formattingEnabled = new PropertyMennager.FormattingEnabledProperty(true);
                properties.Add(formattingEnabled);
                
                properties.Add(location);
                properties.Add(name);
                properties.Add(size);
                properties.Add(tabIndex);
                
                this._name = name.Value;
            }
            
            public override string GetSource()
            {
                return "private System.Windows.Forms.CheckedListBox " + _name + ";";
            }
        }
        
        class ComboBox : Item
        {
            public ComboBox(PropertyMennager.LocationProperty location, PropertyMennager.NameProperty name,
                PropertyMennager.SizeProperty size, PropertyMennager.TabIndexProperty tabIndex)
            {
                PropertyMennager.FormattingEnabledProperty formattingEnabled = new PropertyMennager.FormattingEnabledProperty(true);
                properties.Add(formattingEnabled);
                
                properties.Add(location);
                properties.Add(name);
                properties.Add(size);
                properties.Add(tabIndex);
                
                this._name = name.Value;
            }
            
            public override string GetSource()
            {
                return "private System.Windows.Forms.ComboBox " + _name + ";";
            }
        }
        
        class DateTimePicker : Item
        {
            public DateTimePicker(PropertyMennager.LocationProperty location, PropertyMennager.NameProperty name,
                PropertyMennager.SizeProperty size, PropertyMennager.TabIndexProperty tabIndex)
            {
                properties.Add(location);
                properties.Add(name);
                properties.Add(size);
                properties.Add(tabIndex);
                
                this._name = name.Value;
            }
            
            public override string GetSource()
            {
                return "private System.Windows.Forms.DateTimePicker " + _name + ";";
            }
        }

        public class Lable : Item
        {
            public Lable(PropertyMennager.LocationProperty location, PropertyMennager.NameProperty name,
                PropertyMennager.SizeProperty size, PropertyMennager.TabIndexProperty tabIndex)
            {
                properties.Add(location);
                properties.Add(name);
                properties.Add(size);
                properties.Add(tabIndex);
                this._name = name.Value;
            }

            public override string GetSource()
            {
                return "private System.Windows.Forms.Label " + _name + ";";
            }
        }
        
        class LinkLable : ItemMennager.Lable
        {
            public LinkLable(PropertyMennager.LocationProperty location, PropertyMennager.NameProperty name,
                PropertyMennager.SizeProperty size, PropertyMennager.TabIndexProperty tabIndex) 
                : base(location, name, size, tabIndex)
            {
                PropertyMennager.TabStopProperty tabstop = new PropertyMennager.TabStopProperty(true);
                properties.Add(tabstop);
            }
            
            public override string GetSource()
            {
                return "private System.Windows.Forms.LinkLabel " + _name + ";";
            }
        }

        //TODO:: Pointer
        //TODO:: ListBox
        //TODO:: ListView
        //TODO:: MaskedTextBox
        //TODO:: MonthCalendar
        //TODO:: NotifyIcon
        //TODO:: NumericUpDown
        //TODO:: PictureBox
        //TODO:: ProgressBar
        //TODO:: RadioButton
        //TODO:: RichTextBox
        //TODO:: TextBox
        //TODO:: ToolTip
        //TODO:: TreeView
        //TODO:: WebBrowser
        //TODO:: Form
        
        #endregion
    }

    public abstract class Item
    {
        protected List<Iproperty> properties;
        public List<Iproperty> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        public string _name;
        public string Name
        {
            get { return _name; }
        }
        
        public void EditProperty(Iproperty property)
        {
            foreach (var item in properties)
            {
                if(property.GetName() == item.GetName())
                {
                    properties.Remove(item);
                    properties.Add(property);
                }
            }
        }

        public string PrintItem()
        {
            string result = "//\n" + "//" + _name + "\n" + "//\n";
            foreach (var item in properties)
            {
                result = "this." + _name + "." + item.GetName() + " = " + item.GiveLine() + ";\n";
            }

            return result;
        }
        
        public void SetName(string name)
        {
            _name = name;
            EditProperty(new PropertyMennager.NameProperty(name));
        }

        public abstract string GetSource();
    }
}