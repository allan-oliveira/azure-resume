window.addEventListener('load', (event) => {
    getResumeVisitorsCounter();
});

const getResumeVisitorsCounter = async () => {
    //const local = 'http://localhost:7071/api/GetResumeVisitorsCounter';
    const live = 'https://resumevisitorscounterfunctionapp.azurewebsites.net/api/GetResumeVisitorsCounter?code=Fj1V0dOg02Uv5jSvyXqZWnGO6XfDNiVlLF9XwjDN7dssbPBdZFTBYA=='
    await fetch(live)
        .then((response) => {
            return response.json();
        })
        .then((visitorsCounter) => {
            document.getElementById('counter').innerText = visitorsCounter.count;
        })
        .catch(function(err) {
            console.error(err);
        });
}