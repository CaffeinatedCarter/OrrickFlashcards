#pragma checksum "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "382279ee5cbb44fed70c7fd46051fc10f440166c"
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
#line 5 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
using Flashcardgenerator.Models.Localhost;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(FullWidthLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/edit-card/{cardId}")]
    public partial class EditCard : Flashcardgenerator.Pages.EditCardComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(3, "div");
                __builder2.AddAttribute(4, "class", "row");
                __builder2.OpenElement(5, "div");
                __builder2.AddAttribute(6, "class", "col-md-9");
                __builder2.OpenComponent<Radzen.Blazor.RadzenLabel>(7);
                __builder2.AddAttribute(8, "style", "font-weight: bold");
                __builder2.AddAttribute(9, "Text", "Item no longer available.");
                __builder2.AddAttribute(10, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 12 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                           !canEdit

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(11, "\n      ");
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "class", "col-md-3");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(14);
                __builder2.AddAttribute(15, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 16 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                   ButtonStyle.Secondary

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(16, "style", "margin-bottom: 20px");
                __builder2.AddAttribute(17, "Text", "Close");
                __builder2.AddAttribute(18, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 16 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                              !canEdit

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                                                 CloseButtonClick

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(20, "\n    ");
                __builder2.OpenElement(21, "div");
                __builder2.AddAttribute(22, "class", "row");
                __builder2.OpenElement(23, "div");
                __builder2.AddAttribute(24, "class", "col-md-9");
                __builder2.OpenComponent<Radzen.Blazor.RadzenLabel>(25);
                __builder2.AddAttribute(26, "style", "font-weight: bold");
                __builder2.AddAttribute(27, "Text", "Another user has made conflicting changes to one or more of the fields you have modified. Please reload.");
                __builder2.AddAttribute(28, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 22 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                                                                                         hasChanges

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(29, "\n      ");
                __builder2.OpenElement(30, "div");
                __builder2.AddAttribute(31, "class", "col-md-3");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(32);
                __builder2.AddAttribute(33, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 26 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                   ButtonStyle.Secondary

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(34, "Icon", "autorenew");
                __builder2.AddAttribute(35, "style", "margin-bottom: 20px");
                __builder2.AddAttribute(36, "Text", "Reload");
                __builder2.AddAttribute(37, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 26 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                                               hasChanges

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(38, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 26 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                                                                   Button0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.AddMarkupContent(39, "\n    ");
                __builder2.OpenElement(40, "div");
                __builder2.AddAttribute(41, "class", "row");
                __builder2.OpenElement(42, "div");
                __builder2.AddAttribute(43, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenTemplateForm<Flashcardgenerator.Models.Localhost.Card>>(44);
                __builder2.AddAttribute(45, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Flashcardgenerator.Models.Localhost.Card>(
#nullable restore
#line 32 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                   card

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(46, "Visible", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                     card != null && canEdit

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(47, "Submit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Flashcardgenerator.Models.Localhost.Card>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Flashcardgenerator.Models.Localhost.Card>(this, 
#nullable restore
#line 32 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                                                        Form0Submit

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(48, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder3) => {
                    __builder3.OpenElement(49, "div");
                    __builder3.AddAttribute(50, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(51, "class", "row");
                    __builder3.OpenElement(52, "div");
                    __builder3.AddAttribute(53, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(54);
                    __builder3.AddAttribute(55, "Component", "Question");
                    __builder3.AddAttribute(56, "style", "width: 100%");
                    __builder3.AddAttribute(57, "Text", "Question");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(58, "\n              ");
                    __builder3.OpenElement(59, "div");
                    __builder3.AddAttribute(60, "class", "col-md-9");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextArea>(61);
                    __builder3.AddAttribute(62, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 40 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                           480

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(63, "style", "height: ; width: 100%");
                    __builder3.AddAttribute(64, "Name", "Textarea0");
                    __builder3.AddAttribute(65, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 40 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                             card.Question

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(66, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => card.Question = __value, card.Question))));
                    __builder3.AddAttribute(67, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => card.Question));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(68, "\n            ");
                    __builder3.OpenElement(69, "div");
                    __builder3.AddAttribute(70, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(71, "class", "row");
                    __builder3.OpenElement(72, "div");
                    __builder3.AddAttribute(73, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(74);
                    __builder3.AddAttribute(75, "Component", "categoryId");
                    __builder3.AddAttribute(76, "style", "width: 100%");
                    __builder3.AddAttribute(77, "Text", "Category");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(78, "\n              ");
                    __builder3.OpenElement(79, "div");
                    __builder3.AddAttribute(80, "class", "col-md-9");
                    __Blazor.Flashcardgenerator.Pages.EditCard.TypeInference.CreateRadzenDropDownDataGrid_0(__builder3, 81, 82, 
#nullable restore
#line 50 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                               getCategoriesForcategoryIdResult

#line default
#line hidden
#nullable disable
                    , 83, 
#nullable restore
#line 50 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                           false

#line default
#line hidden
#nullable disable
                    , 84, "Choose Category", 85, 
#nullable restore
#line 50 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                                                            false

#line default
#line hidden
#nullable disable
                    , 86, 
#nullable restore
#line 50 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                                                                               false

#line default
#line hidden
#nullable disable
                    , 87, "width: 100%", 88, "name", 89, "categoryId", 90, "CategoryId", 91, 
#nullable restore
#line 50 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                                                                                                                                             card.categoryId

#line default
#line hidden
#nullable disable
                    , 92, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => card.categoryId = __value, card.categoryId)), 93, () => card.categoryId);
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(94, "\n            ");
                    __builder3.OpenElement(95, "div");
                    __builder3.AddAttribute(96, "style", "margin-bottom: 1rem");
                    __builder3.AddAttribute(97, "class", "row");
                    __builder3.OpenElement(98, "div");
                    __builder3.AddAttribute(99, "class", "col-md-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenLabel>(100);
                    __builder3.AddAttribute(101, "Component", "textarea0");
                    __builder3.AddAttribute(102, "style", "width: 100%");
                    __builder3.AddAttribute(103, "Text", "Answer");
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(104, "\n              ");
                    __builder3.OpenElement(105, "div");
                    __builder3.AddAttribute(106, "class", "col-md-9");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenTextArea>(107);
                    __builder3.AddAttribute(108, "MaxLength", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64?>(
#nullable restore
#line 60 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                           480

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(109, "style", "height: 125px; width: 100%");
                    __builder3.AddAttribute(110, "Name", "AnswerField");
                    __builder3.AddAttribute(111, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 60 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                  card.Answer

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(112, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => card.Answer = __value, card.Answer))));
                    __builder3.AddAttribute(113, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => card.Answer));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(114, "\n            ");
                    __builder3.OpenElement(115, "div");
                    __builder3.AddAttribute(116, "class", "row");
                    __builder3.OpenElement(117, "div");
                    __builder3.AddAttribute(118, "class", "col offset-sm-3");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(119);
                    __builder3.AddAttribute(120, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 66 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                           ButtonStyle.Primary

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(121, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonType>(
#nullable restore
#line 66 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                            ButtonType.Submit

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(122, "Icon", "save");
                    __builder3.AddAttribute(123, "Text", "Save");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(124, "\n                ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenButton>(125);
                    __builder3.AddAttribute(126, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 68 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                           ButtonStyle.Light

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(127, "style", "margin-left: 1rem");
                    __builder3.AddAttribute(128, "Text", "Cancel");
                    __builder3.AddAttribute(129, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 68 "/Users/carter/Documents/GitHub/OrrickFlashcards/server/Pages/EditCard.razor"
                                                                                                              Button4Click

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
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
namespace __Blazor.Flashcardgenerator.Pages.EditCard
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateRadzenDropDownDataGrid_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Collections.IEnumerable __arg0, int __seq1, global::System.Boolean __arg1, int __seq2, global::System.String __arg2, int __seq3, global::System.Boolean __arg3, int __seq4, global::System.Boolean __arg4, int __seq5, System.Object __arg5, int __seq6, global::System.String __arg6, int __seq7, global::System.String __arg7, int __seq8, global::System.String __arg8, int __seq9, global::System.Object __arg9, int __seq10, global::Microsoft.AspNetCore.Components.EventCallback<TValue> __arg10, int __seq11, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg11)
        {
        __builder.OpenComponent<global::Radzen.Blazor.RadzenDropDownDataGrid<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Data", __arg0);
        __builder.AddAttribute(__seq1, "Disabled", __arg1);
        __builder.AddAttribute(__seq2, "Placeholder", __arg2);
        __builder.AddAttribute(__seq3, "Responsive", __arg3);
        __builder.AddAttribute(__seq4, "ShowSearch", __arg4);
        __builder.AddAttribute(__seq5, "style", __arg5);
        __builder.AddAttribute(__seq6, "TextProperty", __arg6);
        __builder.AddAttribute(__seq7, "ValueProperty", __arg7);
        __builder.AddAttribute(__seq8, "Name", __arg8);
        __builder.AddAttribute(__seq9, "Value", __arg9);
        __builder.AddAttribute(__seq10, "ValueChanged", __arg10);
        __builder.AddAttribute(__seq11, "ValueExpression", __arg11);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
