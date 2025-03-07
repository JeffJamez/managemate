window.setCookie = function (name, value) {
  document.cookie = `${name}=${value}; path=/`;
};

window.getCookie = function (name) {
  const value = `; ${document.cookie}`;
  const parts = value.split(`; ${name}=`);
  if (parts.length === 2) return parts.pop().split(";").shift();
};

window.deleteCookie = function (name) {
  document.cookie = name + "=; expires=Thu, 01 Jan 1970 00:00:01 GMT; path=/";
};

window.clearAllCookies = function () {
  document.cookie.split(";").forEach(function (c) {
    document.cookie =
      c.trim() + "=;expires=" + new Date(0).toUTCString() + ";path=/";
  });
};
