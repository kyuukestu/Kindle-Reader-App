//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("mobile_library.ViewsPages.HomeTabs.LibraryView.xaml", "ViewsPages/HomeTabs/LibraryView.xaml", typeof(global::mobile_library.ViewsPages.LibraryView))]

namespace mobile_library.ViewsPages {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("ViewsPages/HomeTabs/LibraryView.xaml")]
    public partial class LibraryView : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.RefreshView LibraryViewRefresh;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ImageButton DeleteButton;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.CollectionView LibraryCollectionView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(LibraryView));
            LibraryViewRefresh = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.RefreshView>(this, "LibraryViewRefresh");
            DeleteButton = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ImageButton>(this, "DeleteButton");
            LibraryCollectionView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.CollectionView>(this, "LibraryCollectionView");
        }
    }
}
