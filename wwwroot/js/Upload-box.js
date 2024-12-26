
const uploadButton = document.getElementById("uploadButton");
const imageUpload = document.getElementById("imageUpload");
const galleryContainer = document.querySelector(".gallery-container");

imageUpload.addEventListener("change",()=>{
    const file=imageUpload.files[0];
    const previewContainer=document.querySelector(".image-preview");
    if(file){
        const reader=new FileReader();
        reader.onload=function(e){
            previewContainer.style.backgroundImage='url(${e.target.result})';
            previewContainer.style.display="block";
        };
        reader.readAsDataURL(file);
    }else{
        previewContainer.style.display="none";
    }
});
uploadButton.addEventListener("click", () => {
    const file = imageUpload.files[0];
    if (file) {
        const reader = new FileReader();
        
        reader.onload = function(e) {
            const newImageUrl = e.target.result;
            
            
            const newBox = document.createElement("div");
            newBox.classList.add("box");
            newBox.style.setProperty("--img", `url(${newImageUrl})`);
            newBox.setAttribute("data-text", "تصویر جدید");

          
            const likeButton = document.createElement("div");
            likeButton.classList.add("like-button");
            newBox.appendChild(likeButton);

            newBox.style.opacity="0";
            newBox.style.transform="scale(0.9)";
            galleryContainer.appendChild(newBox);

            setTimeout(()=>{
                newBox.style.opacity="1";
                newBox.style.transform="scale(1)";
                newBox.style.transition="all 0.5s ease";
            },100);
        };

        reader.readAsDataURL(file); 
    } else {
        alert("لطفاً یک تصویر انتخاب کنید!");
    }
});