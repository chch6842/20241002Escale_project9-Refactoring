// 从 localStorage 读取设置并初始化表单
window.onload = function() {
  var startTime = localStorage.getItem('startTime') || '0';
  var trtime = localStorage.getItem('trtime') || '0';
  var endTime = localStorage.getItem('endTime') || '70';
  var vid = localStorage.getItem('vid') || 'c1TmVdHdpZE';

  document.getElementById('startTime').value = startTime;
  document.getElementById('trtime').value = trtime;
  document.getElementById('endTime').value = endTime;
  document.getElementById('vid').value = vid;
}

function updateSettings() {
  var startTime = document.getElementById('startTime').value;
  var trtime = document.getElementById('trtime').value;
  var endTime = document.getElementById('endTime').value;
  var vid = document.getElementById('vid').value;

  localStorage.setItem('startTime', startTime);
  localStorage.setItem('trtime', trtime);
  localStorage.setItem('endTime', endTime);
  localStorage.setItem('vid', vid);

  alert('設置已更新');
  // Dispatch a custom event to notify index.js about the changes
  window.dispatchEvent(new Event('settingsUpdated'));
}


/*
function updateSettings() {
    var startTime = document.getElementById('startTime').value;
    var trtime = document.getElementById('trtime').value;
    var endTime = document.getElementById('endTime').value;
    var vid = document.getElementById('vid').value;

    localStorage.setItem('startTime', startTime);
    localStorage.setItem('trtime', trtime);
    localStorage.setItem('endTime', endTime);
    localStorage.setItem('vid', vid);

    alert('設置已更新');
      // Reload the page to apply the new settings
    location.reload();
}
*/
//---------背景設定--------------------
var player;
var startTimea = 4; // 開始時間（秒）
var trtimea = 10;
var endTimea = 23;  // 結束時間（秒）
var vida = '9jBA3SA2aIs'; // 替換為你的影片ID

function onYouTubeIframeAPIReady() {
    player = new YT.Player('player', {
        height: '360',
        width: '640',
        videoId: vida, // 替換為你的影片ID
        playerVars: {
            'autoplay': 1,            // 自動播放
            'controls': 0,            // 不顯示控制項
            'showinfo': 0,            // 不顯示影片資訊（此參數在新版API中已被廢棄）
            'modestbranding': 1,      // 隱藏YouTube標誌
            'loop': 1,                // 迴圈播放
            'mute': 1,                // 靜音播放
            'start': startTimea,       // 設置開始播放時間
            'playlist': vida,          // 替換為你的影片ID
        },
        events: {
            'onReady': onPlayerReady,           // 當播放器準備好時觸發的事件處理函數
            'onStateChange': onPlayerStateChange // 當播放器狀態改變時觸發的事件處理函數
        }
    });
}

function onPlayerReady(event) {
    event.target.playVideo(); // 播放影片
}

function onPlayerStateChange(event) {
    if (event.data == YT.PlayerState.PLAYING) {
        var checkTime = function() {
            var currentTime = player.getCurrentTime();
            if (currentTime >= endTimea) {
                player.seekTo(trtimea); // 當到達結束時間時，重新跳轉到開始時間
            }
            setTimeout(checkTime, 100); // 每秒檢查一次時間
        };
        checkTime(); // 開始檢查時間
    }
}
