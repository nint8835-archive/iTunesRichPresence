using System.Net.Http;
using System.Threading.Tasks;
using iTunesRichPresence_Rewrite.API.Responses;

namespace iTunesRichPresence_Rewrite.API {
    class APIConnector {

        private const string APIAddress = "http://localhost:8181";
        private const string PatronStatusEndpoint = APIAddress + "/status";
        private readonly HttpClient _client = new HttpClient();

        public string emailAddress;

        public APIConnector(string email) {
            emailAddress = email;
        }

        public async Task<PatronStatusResponse> getPatronStatus() {
        }

    }
}
