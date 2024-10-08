var player;
var startTime = 3; // 開始時間（秒）
var trtime = 10;
var endTime = 19;  // 結束時間（秒）
var vid = '9jBA3SA2aIs'; // 替換為你的影片ID

function onYouTubeIframeAPIReady() {
  var vid = localStorage.getItem('vid') || 'KGtwHvV9_MA';
  var startTime = parseInt(localStorage.getItem('startTime')) || 0;

  player = new YT.Player('player', {
    videoId: vid,
    playerVars: {
      'autoplay': 1,            // 自動播放
      'controls': 0,            // 不顯示控制項
      'modestbranding': 1,      // 隱藏YouTube標誌
      'loop': 1,                // 迴圈播放
      'mute': 1,                // 靜音播放
      'loop': 1,
      'playlist': vid,
      'start': startTime,
    },
    events: {
      'onReady': onPlayerReady,
      'onStateChange': onPlayerStateChange
    }
  });
}

function onPlayerReady(event) {
            event.target.setPlaybackQuality('highres');  // 最高畫質
            event.target.playVideo();  // 開始播放
        }

function onPlayerStateChange(event) {
  if (event.data == YT.PlayerState.PLAYING) {
        var checkTime = function() {
            var currentTime = player.getCurrentTime();
            if (currentTime >= endTime) {
                player.seekTo(trtime); // 當到達結束時間時，重新跳轉到開始時間
            }
            setTimeout(checkTime, 100); // 每秒檢查一次時間
        };
        checkTime(); // 開始檢查時間
    }
}

// Listen for the custom 'settingsUpdated' event
window.addEventListener('settingsUpdated', function() {
  // Update the player with the new settings
  var vid = localStorage.getItem('vid');
  var startTime = parseInt(localStorage.getItem('startTime')) || 0;

  player.loadVideoById({
    videoId: vid,
    startSeconds: startTime
  });
});

/*
var player;

function getSetting(key, defaultValue) {
    var value = localStorage.getItem(key);
    console.log(`Getting setting ${key}: ${value}`);
    if (value === 'auto' || value === null || isNaN(value)) {
        return defaultValue;
    }
    return parseFloat(value);
}

var startTime = getSetting('startTime', 4); // 開始時間（秒）
var trtime = getSetting('trtime', 10); // 跳轉時間（秒）
var endTime = getSetting('endTime', 60);  // 結束時間（秒）
var vid = localStorage.getItem('vid') || 'auto'; // 替換為'auto'

// 設置預設值
if (vid === 'auto') {
    vid = 'c1TmVdHdpZE'; // 預設影片ID
}

console.log(`Player settings: startTime=${startTime}, trtime=${trtime}, endTime=${endTime}, vid=${vid}`);

function onYouTubeIframeAPIReady() {
    console.log('YouTube Iframe API Ready');
    player = new YT.Player('player', {
        height: '360',
        width: '640',
        videoId: vid, // 替換為你的影片ID
        playerVars: {
            'autoplay': 1,            // 自動播放
            'controls': 0,            // 不顯示控制項
                        'modestbranding': 1,      // 隱藏YouTube標誌
            'loop': 1,                // 迴圈播放
            'mute': 1,                // 靜音播放
            'start': startTime,       // 設置開始播放時間
            'playlist': vid,          // 替換為你的影片ID
        },
        events: {
            'onReady': onPlayerReady,           // 當播放器準備好時觸發的事件處理函數
            'onStateChange': onPlayerStateChange // 當播放器狀態改變時觸發的事件處理函數
        }
    });
}

function onPlayerReady(event) {
    console.log('Player Ready');
    event.target.playVideo(); // 播放影片
}

function onPlayerStateChange(event) {
    if (event.data == YT.PlayerState.PLAYING) {
        console.log('Player Playing');
        var checkTime = function() {
            var currentTime = player.getCurrentTime();
            console.log(`Current time: ${currentTime}`);
            if (currentTime >= endTime) {
                player.seekTo(trtime); // 當到達結束時間時，重新跳轉到開始時間
            }
            setTimeout(checkTime, 100); // 每秒檢查一次時間
        };
        checkTime(); // 開始檢查時間
    }
}

// 确保 YouTube API 脚本加载完成后执行
if (typeof YT === 'undefined' || typeof YT.Player === 'undefined') {
    var tag = document.createElement('script');
    tag.src = "https://www.youtube.com/iframe_api";
    var firstScriptTag = document.getElementsByTagName('script')[0];
    firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);
}

/*會員登入登出設定
document.addEventListener("DOMContentLoaded", function () {
  var userName = localStorage.getItem("userName");
  if (userName) {
    document.getElementById("user-name").innerText = `VIP會員, ${userName}, 您好!`;
    document.getElementById("logout-btn").style.display = "inline-block";
  }

  document.getElementById("logout-btn").addEventListener("click", function () {
    localStorage.removeItem("userName");
    window.location.href = "index.html";
  });
});
*/
document.addEventListener('DOMContentLoaded', () => {
  const button = document.getElementById('showCardButton');
  const cardContainer = document.getElementById('card');

  button.addEventListener('mouseover', () => {
    cardContainer.style.display = 'block';
  });

  button.addEventListener('mouseout', () => {
    cardContainer.style.display = 'none';
  });
});
