
async function ConfirmSubscription() {

    const querryString = window.location.search;
    const urlParams = new URLSearchParams(querryString);
    const emailParam = urlParams.get("email");
    const verificationCodeParam = urlParams.get("verificationCode");
    console.log(verificationCodeParam);
    console.log(emailParam);
    //var response = axios.patch("/api/Subscribe", { Email: emailParam, VerificationCode: verificationCodeParam });
    //console.log(response.data);
}