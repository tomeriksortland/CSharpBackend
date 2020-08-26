

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

    var response = await axios.post("/api/Subscribe", { Name: nameInput, Email: emailInput });
    
}