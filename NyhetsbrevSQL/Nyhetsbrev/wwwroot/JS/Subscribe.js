

var html;


function show() {
    html = `
    <div>
    <h1>Subscribe to newsletter!</h1>
    
      <label>First Name</label>
      <input type="text" id="nameInput" name="firstname" placeholder="Your name..">
  
      <label>Email</label>
      <input type="text" id="emailInput" name="lastname" placeholder="Your email..">
    
      <input type="submit" onclick="Subscribe()">

    
  </div>

        `;

    content.innerHTML = html;
}

async function Subscribe() {
    var nameInput = document.getElementById("nameInput").value.toString();
    var emailInput = document.getElementById("emailInput").value.toString();
    
     var response = await axios({
        method: 'post',
        url: '/api/Subscribe',
        data: {
          Name: nameInput,
          Email: emailInput
        }
      });

     if (response.data === true) emailSentHTML(nameInput, emailInput);
     else{

         emailSentHTMLFailed();
     }
    
}

function emailSentHTML(nameInput, emailInput) {

    html = `
            <div>
            <h2> Takk for at du meldte deg på nyhetsbrev ${nameInput}. Logg inn på ${emailInput} for å bekrefte abonomentet.</h2>
            
            </div>

           `
           content.innerHTML = html;
}

function emailSentHTMLFailed(){
    html = `
            <h2></h2>
    `;
}