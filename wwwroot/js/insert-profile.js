function selectProfile(image) {
    const selectedImage = document.getElementById("selected-profile-image");
    selectedImage.src = image.src;
}

document.getElementById("form_submition").addEventListener("submit", function () {
    const selectedImage = document.getElementById("selected-profile-image");
    document.getElementById("selected-image").value = selectedImage.src;

})