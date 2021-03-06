﻿using System;
using System.Linq;
using Microsoft.VisualStudio.ConnectedServices;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag.Commands.CodeGeneration;
using Unchase.OpenAPI.ConnectedService.Views;

namespace Unchase.OpenAPI.ConnectedService.ViewModels
{
    internal class CSharpClientSettingsViewModel : ConnectedServiceWizardPage
    {
        public string GeneratedFileName { get; set; }

        public SwaggerToCSharpClientCommand Command { get; set; } = new SwaggerToCSharpClientCommand
        {
            Namespace = string.Empty,
            OperationGenerationMode = OperationGenerationMode.SingleClientFromPathSegments
        };

        /// <summary>Gets the list of operation modes. </summary>
        public OperationGenerationMode[] OperationGenerationModes { get; } = Enum.GetNames(typeof(OperationGenerationMode))
            .Select(t => (OperationGenerationMode)Enum.Parse(typeof(OperationGenerationMode), t))
            .ToArray();

        /// <summary>Gets the list of class styles. </summary>
        public CSharpClassStyle[] ClassStyles { get; } = Enum.GetNames(typeof(CSharpClassStyle))
            .Select(t => (CSharpClassStyle)Enum.Parse(typeof(CSharpClassStyle), t))
            .ToArray();

        public CSharpClientSettingsViewModel() : base()
        {
            this.Title = "CSharp Client Settings";
            this.Description = "Settings for generating CSharp client";
            this.Legend = "CSharp Client Settings";
            this.View = new CSharpClientSettings {DataContext = this};
        }
    }
}
