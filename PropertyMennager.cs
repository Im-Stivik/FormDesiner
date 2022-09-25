using System;
using System.Configuration;
using System.Drawing;
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
            Object,
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
            BackgroundImage,
            BackgroundImageLayout,
            Cursor,
            FlatAppearance, //TODO: this
            BorderStyle,
            FlatStyle,
            ForeColor,
            Image,
            ImageAlign,
            ImageIndex,
            ImageKey,
            ImageList,
            RightToLeft,
            TextAlign,
            UseMnemonic,
            UseWaitCursor,
            AllowDrop,
            AutoEllipsis,
            ContextMenuStrip,
            Enabled,
            UseCompatibleTextRendering,
            Visible,
            ApplicationSettings,
            DataBindings,
            Tag,
            GenerateMember,
            Locked,
            Modifiers,
            CausesValidation,
            Anchor,
            Dock,
            Margin,
            MaximumSize,
            MinimumSize,
            Padding,
            
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
                    System.Drawing.Point value = (System.Drawing.Point)Value;
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
                    System.Drawing.Size value = (System.Drawing.Size)Value;
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
                
                public override string GetLine()
                {
                    return Name + " = System.Windows.Forms.AccessibleRole." + Value + ";";
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
                    System.Drawing.Color value = (System.Drawing.Color)Value;
                    return Name + " = Color.FromArgb(" + value.A + ", " + value.R + ", " + value.G + ", " + value.B +
                           ");";
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
                    System.Drawing.Font value = (System.Drawing.Font)Value;
                    return Name + " = new Font(\"" + value.Name + "\", " + value.Size + ", " + value.Style + ");";
                }
            }

            public class BackGroundImageProperty : Property
            {
                public BackGroundImageProperty(System.Drawing.Image value) : base(PropertyNames.BackgroundImage,
                    value, DataTypes.Image)
                {
                }

                public override string GetLine()
                {
                    return Name + " = Image.FromFile(\"" + Value + "\");";
                }
            }

            public class BackGroundImageLayoutProperty : Property
            {
                public BackGroundImageLayoutProperty(ImageLayout value) : base(PropertyNames.BackgroundImageLayout,
                    value, DataTypes.Enum)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = System.Windows.Forms.ImageLayout." + Value + ";";
                }
            }

            public class CursorProperty : Property
            {
                public CursorProperty(Cursor value) : base(PropertyNames.Cursor,
                    value, DataTypes.Object)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = System.Windows.Forms.Cursors." + Value + ";";
                }
            }

            public class BorderStyleProperty : Property
            {
                public BorderStyleProperty(BorderStyle value) : base(PropertyNames.BorderStyle,
                    value, DataTypes.Enum)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = System.Windows.Forms.BorderStyle." + Value + ";";
                }
            }

            public class FlatStyleProperty : Property
            {
                public FlatStyleProperty(FlatStyle value) : base(PropertyNames.FlatStyle,
                    value, DataTypes.Enum)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = System.Windows.Forms.FlatStyle." + Value + ";";
                }
            }

            public class ImageProperty : Property
            {
                public ImageProperty(System.Drawing.Image value) : base(PropertyNames.Image,
                    value, DataTypes.Image)
                {
                }

                public override string GetLine()
                {
                    return Name + " = Image.FromFile(\"" + Value + "\");";
                }
            }

            public class ForeColorProperty : Property
            {
                public ForeColorProperty(System.Drawing.Color value) : base(PropertyNames.ForeColor,
                    value, DataTypes.Color)
                {
                }
                
                public override string GetLine()
                {
                    System.Drawing.Color value = (System.Drawing.Color)Value;
                    return Name + " = Color.FromArgb(" + value.A + ", " + value.R + ", " + value.G + ", " + value.B +
                           ");";
                }
            }
            
            public class ImageAlignProperty : Property
            {
                public ImageAlignProperty(ContentAlignment value) : base(PropertyNames.ImageAlign,
                    value, DataTypes.Enum)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = System.Drawing.ContentAlignment." + Value + ";";
                }
            }
            
            public class ImageIndexProperty : Property
            {
                public ImageIndexProperty(int value) : base(PropertyNames.ImageIndex,
                    value, DataTypes.Int)
                {
                }
            }
            
            public class ImageKeyProperty : Property
            {
                public ImageKeyProperty(string value) : base(PropertyNames.ImageKey,
                    value, DataTypes.String)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = \"" + Value + "\";";
                }
            }
            
            public class ImageListProperty : Property
            {
                public ImageListProperty(ImageList value) : base(PropertyNames.ImageList,
                    value, DataTypes.Object)
                {
                }
            }
            
            public class RightToLeftProperty : Property
            {
                public RightToLeftProperty(RightToLeft value) : base(PropertyNames.RightToLeft,
                    value, DataTypes.Enum)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = System.Windows.Forms.RightToLeft." + Value + ";";
                }
            }
            
            public class TextAlignProperty : Property
            {
                public TextAlignProperty(ContentAlignment value) : base(PropertyNames.TextAlign,
                    value, DataTypes.Enum)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = System.Drawing.ContentAlignment." + Value + ";";
                }
            }
            
            public class UseMnemonicProperty : Property
            {
                public UseMnemonicProperty(bool value) : base(PropertyNames.UseMnemonic,
                    value, DataTypes.Boolean)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = " + Value + ";";
                }
            }
            
            public class UseWaitCursorProperty : Property
            {
                public UseWaitCursorProperty(bool value) : base(PropertyNames.UseWaitCursor,
                    value, DataTypes.Boolean)
                {
                }
            }
            
            public class AlowDropProperty : Property
            {
                public AlowDropProperty(bool value) : base(PropertyNames.AllowDrop,
                    value, DataTypes.Boolean)
                {
                }
            }
            
            public class AutoEllipsisProperty : Property
            {
                public AutoEllipsisProperty(bool value) : base(PropertyNames.AutoEllipsis,
                    value, DataTypes.Boolean)
                {
                }
            }
            
            public class ContextMenuStripProperty : Property
            {
                public ContextMenuStripProperty(ContextMenuStrip value) : base(PropertyNames.ContextMenuStrip,
                    value, DataTypes.Object)
                {
                }
            }
            
            public class EnabledProperty : Property
            {
                public EnabledProperty(bool value) : base(PropertyNames.Enabled,
                    value, DataTypes.Boolean)
                {
                }
            }
            
            public class UseCompatibleTextRenderingProperty : Property
            {
                public UseCompatibleTextRenderingProperty(bool value) : base(PropertyNames.UseCompatibleTextRendering,
                    value, DataTypes.Boolean)
                {
                }
            }
            
            public class VisibleProperty : Property
            {
                public VisibleProperty(bool value) : base(PropertyNames.Visible,
                    value, DataTypes.Boolean)
                {
                }
            }
            
            public class ApplicationSettingsProperty : Property
            {
                public ApplicationSettingsProperty(ApplicationSettingsBase value) : base(PropertyNames.ApplicationSettings,
                    value, DataTypes.Object)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = Properties.Settings." + Value + ";";
                }
            }
            
            public class DataBindingsProperty : Property
            {
                public DataBindingsProperty(BindingSource value) : base(PropertyNames.DataBindings,
                    value, DataTypes.Object)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = new System.Windows.Forms." + Value + ";";
                }
            }
            
            public class TagProperty : Property
            {
                public TagProperty(object value) : base(PropertyNames.Tag,
                    value, DataTypes.Object)
                {
                }
                
                public override string GetLine()
                {
                    if(Value is string)
                        return Name + " = \"" + Value + "\";";
                    return Name + " = " + Value + ";";
                }
            }
            
            public class GenerateMemberProperty : Property
            {
                public GenerateMemberProperty(bool value) : base(PropertyNames.GenerateMember,
                    value, DataTypes.Boolean)
                {
                }
            }
            
            public class LockedProperty : Property
            {
                public LockedProperty(bool value) : base(PropertyNames.Locked,
                    value, DataTypes.Boolean)
                {
                }
            }
            
            public class ModifiersProperty : Property
            {
                //TODO: make enum
                public ModifiersProperty(string value) : base(PropertyNames.Modifiers,
                    value, DataTypes.Enum)
                {
                }
                
                 public override string GetLine()
                 {
                     //TODO: return modifiers
                     return null;
                 }
            }
            
            public class CausesValidationProperty : Property
            {
                public CausesValidationProperty(bool value) : base(PropertyNames.CausesValidation,
                    value, DataTypes.Boolean)
                {
                }
            }
            
            public class AnchorProperty : Property
            {
                public AnchorProperty(AnchorStyles value) : base(PropertyNames.Anchor,
                    value, DataTypes.Enum)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = System.Windows.Forms.AnchorStyles." + Value + ";";
                }
            }
            
            public class DockProperty : Property
            {
                public DockProperty(DockStyle value) : base(PropertyNames.Dock,
                    value, DataTypes.Enum)
                {
                }
                
                public override string GetLine()
                {
                    return Name + " = System.Windows.Forms.DockStyle." + Value + ";";
                }
            }
            
            public class MarginProperty : Property
            {
                public MarginProperty(Padding value) : base(PropertyNames.Margin,
                    value, DataTypes.Object)
                {
                }
                
                public override string GetLine()
                {
                    //TODO: return padding
                    return Name + " = new System.Windows.Forms.Padding(" + Value + ");";
                }
            }
            
            public class MaximumSizeProperty : Property
            {
                public MaximumSizeProperty(Size value) : base(PropertyNames.MaximumSize,
                    value, DataTypes.Object)
                {
                }
                
                //TODO: return size
            }
            
            public class MinimumSizeProperty : Property
            {
                public MinimumSizeProperty(Size value) : base(PropertyNames.MinimumSize,
                    value, DataTypes.Object)
                {
                }
                
                //TODO: return size
            }
            
            public class PaddingProperty : Property
            {
                public PaddingProperty(Padding value) : base(PropertyNames.Padding,
                    value, DataTypes.Object)
                {
                }
                
                //TODO: return padding
            }

        }
    }
}