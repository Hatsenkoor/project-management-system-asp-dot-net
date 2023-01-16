let videoSource = new Array();
videoSource[0] = 'https://pf.maf.gov.om/images/hermann_en.mp4';
videoSource[1] = 'https://pf.maf.gov.om/images/hermann_ar.mp4';
let i = 0; // global
const videoCount = videoSource.length;
const element = document.getElementById("videoplay");

function videoPlay(videoNum) {
    element.setAttribute("src", videoSource[videoNum]);
    element.autoplay = true;
    element.load();
}
document.getElementById('videoplay').addEventListener('ended', myHandler, false);

videoPlay(i); // load the first video
ensureVideoPlays();	// play the video automatically

function myHandler() {
    i++;
    if (i == videoCount) {
        i = 0;
        videoPlay(i);
    } else {
        videoPlay(i);
    }
}

function ensureVideoPlays() {
    const video = document.getElementById('videoplay');

    if(!video) return;
    
    const promise = video.play();
    if(promise !== undefined){
        promise.then(() => {
            // Autoplay started
        }).catch(error => {
            // Autoplay was prevented.
            video.muted = true;
            video.play();
        });
    }
}