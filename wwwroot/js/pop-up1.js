document.getElementById("uploadButton").addEventListener("click", function() {
    const file = document.getElementById("imageUpload").files[0];
    
    if (!file) {
        const myModal = new bootstrap.Modal(document.getElementById('exampleModal'));
        myModal.show();
    } else {
        alert("فایل آپلود شد!");
    }
});
