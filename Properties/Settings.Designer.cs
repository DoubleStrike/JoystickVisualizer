﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JoystickVisualizer.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("50")]
        public int Timer_PollingIntervalMs {
            get {
                return ((int)(this["Timer_PollingIntervalMs"]));
            }
            set {
                this["Timer_PollingIntervalMs"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("32768")]
        public int Axis_DefaultValue {
            get {
                return ((int)(this["Axis_DefaultValue"]));
            }
            set {
                this["Axis_DefaultValue"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("65535")]
        public string Axis_MaxValue {
            get {
                return ((string)(this["Axis_MaxValue"]));
            }
            set {
                this["Axis_MaxValue"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public int UI_BorderThickness {
            get {
                return ((int)(this["UI_BorderThickness"]));
            }
            set {
                this["UI_BorderThickness"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int UI_CrosshairThickness {
            get {
                return ((int)(this["UI_CrosshairThickness"]));
            }
            set {
                this["UI_CrosshairThickness"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20")]
        public int UI_Default_2dDotSize {
            get {
                return ((int)(this["UI_Default_2dDotSize"]));
            }
            set {
                this["UI_Default_2dDotSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8")]
        public int UI_PovLineThickness {
            get {
                return ((int)(this["UI_PovLineThickness"]));
            }
            set {
                this["UI_PovLineThickness"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30, 30, 30")]
        public global::System.Drawing.Color UI_DarkModeBackground {
            get {
                return ((global::System.Drawing.Color)(this["UI_DarkModeBackground"]));
            }
            set {
                this["UI_DarkModeBackground"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("GradientInactiveCaption")]
        public global::System.Drawing.Color UI_DefaultDotColor {
            get {
                return ((global::System.Drawing.Color)(this["UI_DefaultDotColor"]));
            }
            set {
                this["UI_DefaultDotColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Info")]
        public global::System.Drawing.Color UI_DefaultFrameColor {
            get {
                return ((global::System.Drawing.Color)(this["UI_DefaultFrameColor"]));
            }
            set {
                this["UI_DefaultFrameColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Red")]
        public global::System.Drawing.Color UI_PovLineColor {
            get {
                return ((global::System.Drawing.Color)(this["UI_PovLineColor"]));
            }
            set {
                this["UI_PovLineColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DashDot")]
        public global::System.Drawing.Drawing2D.DashStyle UI_CenterLineDashStyle {
            get {
                return ((global::System.Drawing.Drawing2D.DashStyle)(this["UI_CenterLineDashStyle"]));
            }
            set {
                this["UI_CenterLineDashStyle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Dot")]
        public global::System.Drawing.Drawing2D.DashStyle UI_DotWidthLineDashStyle {
            get {
                return ((global::System.Drawing.Drawing2D.DashStyle)(this["UI_DotWidthLineDashStyle"]));
            }
            set {
                this["UI_DotWidthLineDashStyle"] = value;
            }
        }
    }
}
