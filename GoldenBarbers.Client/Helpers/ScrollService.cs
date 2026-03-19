using Microsoft.JSInterop;

namespace GoldenBarbers.Client.Helpers
{
    public class ScrollService
    {
        private readonly IJSRuntime _js;

        public ScrollService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task ScrollToElement(string elementId)
        {
            await _js.InvokeVoidAsync("scrollService.scrollToElement", elementId);
        }
    }
}
