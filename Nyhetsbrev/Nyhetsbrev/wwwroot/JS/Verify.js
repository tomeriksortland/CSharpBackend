
if (window.location.search.includes("email") && window.location.search.includes("code")) {
    ConfirmSubscription();
}


async function ConfirmSubscription() {

    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const emailParam = urlParams.get("email");
    const verificationCodeParam = urlParams.get("code");
    var response = await axios.patch("/api/Subscribe", { Email: emailParam, VerificationCode: verificationCodeParam });
}