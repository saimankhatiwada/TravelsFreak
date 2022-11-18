using Microsoft.JSInterop;

namespace TravelsFreak.Server.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSucess(this IJSRuntime JsRuntime, string message)
        {
            await JsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime JsRuntime, string message)
        {
            await JsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }
    }
}
