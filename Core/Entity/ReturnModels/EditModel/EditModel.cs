﻿namespace uni_project.Core.Entity.ReturnModels.EditModel
{
    public class EditModel
    {
        public bool IsEdited { get; set; }
        public string Message { get; set; }

        public EditModel(bool isEdited, string message)
        {
            IsEdited = isEdited;
            Message = message;
        }
    }
}
