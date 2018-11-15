<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
<!-- default file list end -->
# How to synchronize the GridControl and PrintPreviewWindow themes


<p>This example demonstrates how you can set the PrintPreviewWindow theme to the currently selected GridControl theme. To do this, set the <a href="http://documentation.devexpress.com/#WPF/DevExpressXpfThemesThemeManager_ThemeNametopic"><u>ThemeManager.ThemeName Attached Property</u></a> in code:</p>

```cs
    ThemeManager.SetThemeName(preview, ThemeManager.GetThemeName(gridControl1));<newline/>
<newline/>

```

<p>Note that in this scenario, the GridControl should be printed via the VisualDataNodeLink like in the <a href="https://www.devexpress.com/Support/Center/p/E2465">How to specify certain page settings programmatically when printing a grid</a> example so that you can access the PrintPreviewWindow (preview variable in this example).</p>

<br/>


