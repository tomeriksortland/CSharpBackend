
if (location.search.includes("email") && location.search.includes("code")) {
    console.log("hei");
    ConfirmSubscription();
}


async function ConfirmSubscription() {

    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const emailParam = urlParams.get("email");
    const verificationCodeParam = urlParams.get("code");
    console.log("HAlla pårrrrrreeeeeøeøeøeeøeø");
    console.log(verificationCodeParam);
    console.log(emailParam);
    //var response = await axios.patch("/api/Subscribe", { Email: emailParam, VerificationCode: verificationCodeParam });
    //console.log(response.data);
}