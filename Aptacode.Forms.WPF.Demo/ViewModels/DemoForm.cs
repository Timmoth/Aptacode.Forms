﻿using Aptacode.CSharp.Common.Patterns.Specification;
using Aptacode.Expressions.Bool.Extensions;
using Aptacode.Forms.Shared.Builders;
using Aptacode.Forms.Shared.Builders.Elements.Composite;
using Aptacode.Forms.Shared.Builders.Elements.Controls;
using Aptacode.Forms.Shared.Builders.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Enums;
using Aptacode.Forms.Shared.EventListeners;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.EventListeners.Specifications.EventSpecifications;
using Aptacode.Forms.Shared.EventListeners.Specifications.FormSpecifications;
using Aptacode.Forms.Shared.Interfaces.Controls;
using Aptacode.Forms.Shared.Models.Elements.Controls;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels;

namespace Aptacode.Forms.Wpf.FormDesigner.ViewModels
{
    public static class DemoForm
    {
        public static FormViewModel CreateForm()
        {
            var htmlContent = new HtmlElementBuilder().SetName("HtmlContent").SetContent(
                    "<h2 style=\"text-align: center;\"><strong>Demo Form<br /></strong></h2>\r\n<p>Test HTML Content embedded in the demo form</p>\r\n<ul>\r\n<li>FirstName / LastName</li>\r\n<li>Years of experiance</li>\r\n<li>Accept Terms and Conditions</li>\r\n<li>Submit</li>\r\n</ul>")
                .Build();

            var firstNameText = new TextElementBuilder()
                .SetName("First Name")
                .SetLabel(ElementLabel.Left("First Name: "))
                .SetDefaultValue("First Name")
                .AddRules(
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MaximumLength_Validator(10))
                        .WithFailMessage("First Name must be less then 10 characters"),
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MinimunLength_Validator(2))
                        .WithFailMessage("First Name must be greater then 2 characters"))
                .Build();

            var lastNameText = new TextElementBuilder()
                .SetName("Last Name")
                .SetLabel(ElementLabel.Left("Last Name: "))
                .SetDefaultValue("Last Name")
                .AddRules(
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MaximumLength_Validator(10))
                        .WithFailMessage("Last Name must be less then 10 characters"),
                    ValidationRule<ITextElementViewModel>.Create(new TextElement_MinimunLength_Validator(2))
                        .WithFailMessage("Last Name must be greater then 2 characters"))
                .Build();

            var personalDetails = new LinearLayoutBuilder().SetName("personalDetails")
                .AddChildren(firstNameText, lastNameText).SetOrientation(LayoutOrientation.Horizontal).Build();


            var experienceSelection = new SelectElementBuilder().SetName("experienceSelection")
                .SetLabel(ElementLabel.Left("How many years experience have you got?")).AddValues("0-1", "1-5", "5+")
                .SetDefaultValue("Select a value").Build();
            var termsAndConditions = new CheckElementBuilder().SetName("TermsAndConditions")
                .SetLabel(ElementLabel.Left("Do you accept the terms and conditions?")).SetContent("Yes / No").AddRules(
                    ValidationRule<ICheckElementViewModel>.Create(new CheckElement_IsChecked_Validator())
                        .WithFailMessage("You must accept the terms and conditions")).Build();

            var submitButton = new ButtonElementBuilder().SetName("Submit Button").SetContent("Submit")
                .SetVerticalAlignment(VerticalAlignment.Bottom).Build();

            var submitEventListenerAcceptsTerms = new EventListener("submit",
                new ElementNameEventSpecification("Submit Button").And(
                    new TypeNameEventSpecification(nameof(ButtonElementClickedEvent))),
                new ElementPropertyFormSpecification("TermsAndConditions", "IsChecked", "True"));

            var submitEventListenerExperience = new EventListener("tooLittleExperiance",
                new ElementNameEventSpecification("Submit Button").And(
                    new TypeNameEventSpecification(nameof(ButtonElementClickedEvent))),
                new ElementPropertyFormSpecification("experienceSelection", "SelectedItem", "0-1"));

            var rowGroup1 = new LinearLayoutBuilder().SetName("Data Entry Rows")
                .AddChildren(htmlContent, personalDetails, experienceSelection, termsAndConditions).Build();

            var rootGroup = new GroupBuilder().SetName("Test Group 1").SetTitle("Demo Form Title")
                .AddChildren(rowGroup1, submitButton).Build();

            var newForm = new FormBuilder().SetName("Demo Form").SetTitle("Demo Form Title").SetRoot(rootGroup)
                .AddEventListeners(submitEventListenerAcceptsTerms, submitEventListenerExperience)
                .Build();

            return new FormViewModel(newForm);
        }
    }
}