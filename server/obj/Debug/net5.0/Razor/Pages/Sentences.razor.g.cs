#pragma checksum "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e084c405e655a69e5156fb91ada6ca5644e546c"
// <auto-generated/>
#pragma warning disable 1591
namespace Flashcardgenerator.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/_Imports.razor"
using Flashcardgenerator.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/_Imports.razor"
using Aspose.Words;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/_Imports.razor"
using PragmaticSegmenterNet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/_Imports.razor"
using BlazorDownloadFile;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
using Flashcardgenerator.Models.Localhost;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(FullWidthLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/sentences")]
    public partial class Sentences : Flashcardgenerator.Pages.SentencesComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenHeading>(3);
                __builder2.AddAttribute(4, "Size", "H1");
                __builder2.AddAttribute(5, "Text", "Sentences");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\n    ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "row");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(11);
                __builder2.AddAttribute(12, "Icon", "add_circle_outline");
                __builder2.AddAttribute(13, "style", "margin-bottom: 10px");
                __builder2.AddAttribute(14, "Text", "Add");
                __builder2.AddAttribute(15, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                               Button0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenSplitButton>(17);
                __builder2.AddAttribute(18, "Icon", "get_app");
                __builder2.AddAttribute(19, "style", "margin-bottom: 10px; margin-left: 10px");
                __builder2.AddAttribute(20, "Text", "Export");
                __builder2.AddAttribute(21, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.Blazor.RadzenSplitButtonItem>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.Blazor.RadzenSplitButtonItem>(this, 
#nullable restore
#line 16 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                               Splitbutton0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(22, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenSplitButtonItem>(23);
                    __builder3.AddAttribute(24, "Text", "Excel");
                    __builder3.AddAttribute(25, "Value", "xlsx");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(26, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenSplitButtonItem>(27);
                    __builder3.AddAttribute(28, "Text", "CSV");
                    __builder3.AddAttribute(29, "Value", "csv");
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(30, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(31);
                __builder2.AddAttribute(32, "Icon", "sync");
                __builder2.AddAttribute(33, "style", "float: right; margin-bottom: 10px");
                __builder2.AddAttribute(34, "Text", "Convert to cards");
                __builder2.AddAttribute(35, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 24 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                            ConvertToCardsClick

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(36, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenTextBox>(37);
                __builder2.AddAttribute(38, "Placeholder", "Search ...");
                __builder2.AddAttribute(39, "style", "display: block; margin-bottom: 10px; width: 100%");
                __builder2.AddAttribute(40, "Name", "Textbox0");
                __builder2.AddAttribute(41, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 26 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                                                     async(args) => {search = $"{args.Value}";await grid0.GoToPage(0);await Load();}

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(42, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenGrid<Flashcardgenerator.Models.Localhost.Sentence>>(43);
                __builder2.AddAttribute(44, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 28 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                 true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(45, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 28 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(46, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 28 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                        true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(47, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<Flashcardgenerator.Models.Localhost.Sentence>>(
#nullable restore
#line 28 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                     getSentencesResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(48, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 28 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                                                     FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(49, "PageSize", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 28 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                                                                                                                                         15

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(50, "RowSelect", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Flashcardgenerator.Models.Localhost.Sentence>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Flashcardgenerator.Models.Localhost.Sentence>(this, 
#nullable restore
#line 28 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                                                                                                                                                         Grid0RowSelect

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(51, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<Flashcardgenerator.Models.Localhost.Sentence>>(52);
                    __builder3.AddAttribute(53, "Property", "Brief.Client.shortName");
                    __builder3.AddAttribute(54, "Title", "Client");
                    __builder3.AddAttribute(55, "Width", "150px");
                    __builder3.AddAttribute(56, "Type", "string");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(57, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<Flashcardgenerator.Models.Localhost.Sentence>>(58);
                    __builder3.AddAttribute(59, "Property", "Brief.briefType");
                    __builder3.AddAttribute(60, "Title", "Brief Type");
                    __builder3.AddAttribute(61, "Width", "150px");
                    __builder3.AddAttribute(62, "Type", "string");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(63, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<Flashcardgenerator.Models.Localhost.Sentence>>(64);
                    __builder3.AddAttribute(65, "Property", "parseNum");
                    __builder3.AddAttribute(66, "Title", "Doc Sen #");
                    __builder3.AddAttribute(67, "Width", "75px");
                    __builder3.AddAttribute(68, "Type", "integer");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(69, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<Flashcardgenerator.Models.Localhost.Sentence>>(70);
                    __builder3.AddAttribute(71, "Property", "content");
                    __builder3.AddAttribute(72, "Title", "Content");
                    __builder3.AddAttribute(73, "Type", "string");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(74, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenGridColumn<Flashcardgenerator.Models.Localhost.Sentence>>(75);
                    __builder3.AddAttribute(76, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 38 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                               false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(77, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 38 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                                false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(78, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.TextAlign>(
#nullable restore
#line 38 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                                                  TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(79, "Title", "Delete");
                    __builder3.AddAttribute(80, "Width", "70px");
                    __builder3.AddAttribute(81, "Type", "integer");
                    __builder3.AddAttribute(82, "Template", (Microsoft.AspNetCore.Components.RenderFragment<Flashcardgenerator.Models.Localhost.Sentence>)((flashcardgeneratorModelsLocalhostSentence) => (__builder4) => {
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(83);
                        __builder4.AddAttribute(84, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 40 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                           ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(85, "Icon", "close");
                        __builder4.AddAttribute(86, "Size", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonSize>(
#nullable restore
#line 40 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                  ButtonSize.Small

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(87, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 40 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                             (args) =>GridDeleteButtonClick(args, flashcardgeneratorModelsLocalhostSentence)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddEventStopPropagationAttribute(88, "onclick", 
#nullable restore
#line 40 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                                                                                                                                                                                                                         true

#line default
#line hidden
#nullable disable
                        );
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentReferenceCapture(89, (__value) => {
#nullable restore
#line 28 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/Sentences.razor"
                          grid0 = (Radzen.Blazor.RadzenGrid<Flashcardgenerator.Models.Localhost.Sentence>)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
