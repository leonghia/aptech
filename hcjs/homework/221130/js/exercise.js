// Get JSON from web API
const currentWeather = (city) => {
    let xhttp = new XMLHttpRequest();
    xhttp.onload = function() {
        // Transform JSON into object/array
        let result = this.responseText;
        let data = JSON.parse(result);
        
        // Working with the object/array
        console.log(data);
        const container = document.querySelector('.container');
        const myRow = document.querySelector('.row');

        // Clear the page
        myRow.innerHTML = "";

        // Generate new page
        for (let i = 0; i < data.list.length; i++) {
            // Add article element with class col-3
            const myArticle = document.createElement('article');
            myRow.appendChild(myArticle);
            myArticle.classList.add('col-12', 'col-xl-3');

            // Add div element with class card
            const myDiv1 = document.createElement('div');
            myArticle.appendChild(myDiv1);
            myDiv1.classList.add('card', 'text-bg-secondary', 'mb-3');
            myDiv1.style.setProperty('background-color', 'RGBA(108,117,125,var(--bs-bg-opacity,.6))', 'important');

            // Add div element with class card body
            const myDiv2 = document.createElement('div');
            myDiv1.appendChild(myDiv2);
            myDiv2.classList.add('card-body');

            // Add h6 element into card body
            const myH6 = document.createElement('h6');
            myDiv2.appendChild(myH6);
            
            // Add time content into myH6
            const time = data.list[i].dt_txt;
            myH6.innerText = time;

            // Add div with display flex to hold temperature and icon image
            const myDiv3 = document.createElement('div');
            myDiv2.appendChild(myDiv3);
            myDiv3.style.display = 'flex';
            myDiv3.style.alignItems = 'center';
            myDiv3.style.justifyContent = 'space-between';
            myDiv3.style.height = '60px';

            // Add h2 element with temperature value
            const myH2 = document.createElement('h2');
            myDiv3.appendChild(myH2);
            myH2.innerText = data.list[i].main.temp;
            myH2.innerHTML += '<sup>o</sup>C';

            // Add icon image
            const myImage = document.createElement('img');
            myDiv3.appendChild(myImage);
            myImage.src = `https://openweathermap.org/img/wn/${data.list[i].weather[0].icon}@2x.png`;

            // Add p element with description
            const myP = document.createElement('p');
            myDiv2.appendChild(myP);
            myP.innerText = data.list[i].weather[0].description;
        }
    }
xhttp.open("GET", `https://api.openweathermap.org/data/2.5/forecast?q=${city},vietnam&appid=09a71427c59d38d6a34f89b47d75975c&units=metric`);

xhttp.send();
}

currentWeather('London');

// Change city based on event-listener
const changeCity = (event) => {
    let city = event.target.value;
    currentWeather(city);
}

// Add event-listener to all buttons
let myButtons = document.getElementsByClassName('btn');
for (let i = 0; i < myButtons.length; i++) {
    myButtons[i].addEventListener('click', changeCity);
}

// Other stylings
document.querySelector('div').style.paddingTop = '50px';
document.querySelector('div').style.paddingBottom = '40px';
const myDiv4 = document.createElement('div');
document.querySelector('footer').appendChild(myDiv4);
myDiv4.setAttribute("style", "text-align:center;color: #fff;font-size:1.2rem");
const myLink = document.createElement('a');
myDiv4.appendChild(myLink);
myLink.innerHTML = 'Crafted by <a href="https://github.com/leonghia/HCJS/tree/master/homework/30-11-22" target="_blank" style="text-decoration:none;color:aqua;"><b>Leo Nghia</b></a> 🧡'

