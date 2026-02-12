using Microsoft.AspNetCore.Components;

namespace Web.Components
{
    public abstract class CustomCheckboxRF<TItem> : ComponentBase
    {
        [Parameter]
        public List<TItem> OptionList { get; set; }

        [Parameter]
        public Func<TItem, string> DisplayText { get; set; }

        [Parameter]
        public Func<TItem, string> ValueText { get; set; }

        [Parameter]
        public List<string> Value { get; set; }

        [Parameter]
        public EventCallback<List<string>> ValueChanged { get; set; }

        [Parameter]
        public string MemberId { get; set; }

        [Parameter]
        public EventCallback<(bool isChecked, string value, string memberId)> OnChange { get; set; }

        protected async Task OnCheckboxChanged(ChangeEventArgs e, string itemValue)
        {
            var isChecked = (bool)e.Value;
            var newValue = Value?.ToList() ?? new List<string>();

            if (isChecked && !newValue.Contains(itemValue))
            {
                newValue.Add(itemValue);
            }
            else if (!isChecked && newValue.Contains(itemValue))
            {
                newValue.Remove(itemValue);
            }

            await ValueChanged.InvokeAsync(newValue);
            await OnChange.InvokeAsync((isChecked, itemValue, MemberId));
        }
    }
}