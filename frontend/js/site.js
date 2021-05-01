window.addEventListener('load', (event) => {
    getResumeVisitorsCounter();
});

const getResumeVisitorsCounter = async () => {
    await fetch('http://localhost:7071/api/GetResumeVisitorsCounter')
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