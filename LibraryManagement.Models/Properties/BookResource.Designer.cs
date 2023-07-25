﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement.Models.Properties {
    using System;
    
    
    /// <summary>
    ///   Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    /// </summary>
    // Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    // -Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    // Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    // mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class BookResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal BookResource() {
        }
        
        /// <summary>
        ///   Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LibraryManagement.Models.Properties.BookResource", typeof(BookResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        ///   Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die ISBN Verifizierung fehlgeschlagen ähnelt.
        /// </summary>
        internal static string ISBN_Error {
            get {
                return ResourceManager.GetString("ISBN_Error", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Ungültige ISBN Nummer (13 numerische Zeichen erforderlich) ähnelt.
        /// </summary>
        internal static string ISBN_Error_Length {
            get {
                return ResourceManager.GetString("ISBN_Error_Length", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Das Feld darf maximal 255 Zeichen enthalten! ähnelt.
        /// </summary>
        internal static string MaxLength {
            get {
                return ResourceManager.GetString("MaxLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Das Feld benötigt mindestens zwei Zeichen! ähnelt.
        /// </summary>
        internal static string MinLength {
            get {
                return ResourceManager.GetString("MinLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Feld darf nicht leer sein! ähnelt.
        /// </summary>
        internal static string Required {
            get {
                return ResourceManager.GetString("Required", resourceCulture);
            }
        }
    }
}