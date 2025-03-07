export function handleLogin(e) {
  e.preventDefault();
  document.getElementById("loginPage").style.display = "none";
  document.getElementById("otpPage").style.display = "block";
  startTimer();
}

export function handleSignup(e) {
  e.preventDefault();
  document.getElementById("signupPage").style.display = "none";
  document.getElementById("otpPage").style.display = "block";
  startTimer();
}

export function showSignup() {
  document.getElementById("loginPage").style.display = "none";
  document.getElementById("signupPage").style.display = "block";
}

export function showLogin() {
  document.getElementById("signupPage").style.display = "none";
  document.getElementById("loginPage").style.display = "block";
}

export function startTimer() {
  let timeLeft = 59;
  const timerElement = document.querySelector(".timer");
  const timer = setInterval(() => {
    if (timeLeft >= 0) {
      timerElement.textContent = `00:${timeLeft.toString().padStart(2, "0")}`;
      timeLeft--;
    } else {
      clearInterval(timer);
    }
  }, 1000);
}

export function initOtpInputs() {
  const otpInputs = document.querySelectorAll(".otp-input");
  otpInputs.forEach((input, index) => {
    input.addEventListener("input", (e) => {
      if (e.target.value && index < otpInputs.length - 1) {
        otpInputs[index + 1].focus();
      }
    });
  });
}

// Call initOtpInputs when the page loads
document.addEventListener("DOMContentLoaded", initOtpInputs);
