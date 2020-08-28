
if (window.location.search.includes("email") && window.location.search.includes("code")) {
    ConfirmSubscription();
}


async function ConfirmSubscription() {

    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const emailParam = urlParams.get("email");
    const verificationCodeParam = urlParams.get("code");
    var response = await axios({
        method: 'patch',
        url: '/api/Subscribe',
        data: {
          email: emailParam,
          verificationCode: verificationCodeParam 
        }
      });
    
      if(response === true) SubscriptionConfirmed();
      else {
          html = `
          <h2>Noe gikk galt med verifiseringen.</h2>
          `
      }
}

function SubscriptionConfirmed(){
    html = `<h2>Du er nå påmeldt og verifisert </h2>`;
}

