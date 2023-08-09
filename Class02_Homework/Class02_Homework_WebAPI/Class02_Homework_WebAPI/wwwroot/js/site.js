const allUsernamesList = document.getElementById('allUsernames');
const indexInput = document.getElementById('indexInput');
const getUserButton = document.getElementById('getUserButton');
const userDetails = document.getElementById('userDetails');

fetch('/api/Users')
    .then(response => response.json())
    .then(usernames => {
        usernames.forEach(username => {
            const li = document.createElement('li');
            li.textContent = username;
            allUsernamesList.appendChild(li);
        });
    })
    .catch(error => console.error('Error fetching usernames:', error));

getUserButton.addEventListener('click', () => {
    const index = parseInt(indexInput.value);
    if (!isNaN(index)) {
        fetch(`/api/Users/${index}`)
            .then(response => response.text())
            .then(result => {
                userDetails.textContent = `User at index ${index}: ${result}`;
            }); 
    } else {
        userDetails.textContent = 'Invalid input. Please enter a valid number.';
    }
}); 