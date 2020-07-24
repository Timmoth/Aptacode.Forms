﻿using System;
using System.Collections.Generic;
using System.Linq;
using Aptacode.Forms.Shared.EventListeners.Events;
using Aptacode.Forms.Shared.Models.Elements.Controls.Fields;
using Aptacode.Forms.Shared.Results;
using Aptacode.Forms.Shared.ValidationRules;
using Aptacode.Forms.Shared.ViewModels.Elements.Interfaces;

namespace Aptacode.Forms.Shared.ViewModels.Elements.Controls.Fields
{
    public class SelectElementViewModel : FieldElementViewModel, ISelectElementViewModel
    {
        public SelectElementViewModel(SelectElement model) : base(model)
        {
            Model = model;
        }

        public override IEnumerable<ValidationResult> Validate()
        {
            return _model.Rules.Select(rule => rule.Validate(this));
        }

        public override FieldElementResult GetResult() => new SelectElementResult(Name, SelectedItem);

        #region Properties

        private SelectElement _model;

        public SelectElement Model
        {
            get
            {
                _model.Values = Items;
                _model.DefaultValue = DefaultSelectedItem;
                return _model;
            }
            set
            {
                SetProperty(ref _model, value);

                Items.Clear();
                if (_model != null)
                {
                    Items.AddRange(_model.Values);
                }

                SelectedItem = _model?.DefaultValue;
                DefaultSelectedItem = _model?.DefaultValue;
            }
        }

        public List<string> Items { get; set; } = new List<string>();

        private string _defaultSelectedItem;

        public string DefaultSelectedItem
        {
            get => _defaultSelectedItem;
            set
            {
                SetProperty(ref _defaultSelectedItem, value);
                if (_model != null)
                {
                    _model.DefaultValue = _defaultSelectedItem;
                }
            }
        }

        private string _selectedItem;

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                if (_model == null)
                {
                    return;
                }

                TriggerEvent(new SelectElementChangedEvent(DateTime.Now, Name, value));
                UpdateValidationMessage();
            }
        }

        #endregion
    }
}