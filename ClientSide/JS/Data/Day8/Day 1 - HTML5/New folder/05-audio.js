var audioTag= document.getElementsByTagName("audio")[0];
console.log(audioTag);

var timeRange = document.getElementById('timeRange');
var volumeRange = document.getElementById('volumeRange')
console.log(timeRange);

var Playlist = document.getElementById('Playlist')


// currentTime --> audio tag
// currentTime --> audioTag.duration
// timeRange.value --> time range


function play(){
    audioTag.play()
}


function pause(){
    audioTag.pause()
}
function Stop(){
    
    pause();
    audioTag.currentTime=0
}

volumeRange.oninput=function(){
    
    audioTag.volume=volumeRange.value/100;
    
}
timeRange.oninput=function(){
    
    audioTag.currentTime= (timeRange.value/100)*audioTag.duration
}

audioTag.ontimeupdate=function(){
    
    
    timeRange.value= (audioTag.currentTime/audioTag.duration)*100
}
Playlist.onclick=function(e){

    audioTag.src= e.target.value;
    play()
}