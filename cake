
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Magical Birthday Cake</title>
    <style>
        /* Global Styles */
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: 'Arial Rounded MT Bold', 'Helvetica Rounded', Arial, sans-serif;
        }

        body {
            background: linear-gradient(135deg, #4842ec, #c4e0ff);
            min-height: 100vh;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            overflow: hidden;
            position: relative;
        }

        /* Floating Balloons */
        .balloon {
            position: absolute;
            width: 40px;
            height: 50px;
            border-radius: 50%;
            animation: float 15s infinite ease-in-out;
            z-index: 1;
        }

        @keyframes float {
            0% {
                transform: translateY(100vh) translateX(0);
                opacity: 1;
            }
            100% {
                transform: translateY(-100px) translateX(50px);
                opacity: 0;
            }
        }

        /* Confetti */
        .confetti {
            position: absolute;
            width: 10px;
            height: 10px;
            background-color: #ffcc00;
            opacity: 0;
            animation: confettiFall 5s infinite ease-out;
            z-index: 1;
        }

        @keyframes confettiFall {
            0% {
                transform: translateY(-10vh) rotate(0deg);
                opacity: 1;
            }
            100% {
                transform: translateY(100vh) rotate(720deg);
                opacity: 0;
            }
        }

        /* Birthday Cake Container */
        .cake-container {
            position: relative;
            width: 300px;
            height: 300px;
            margin: 20px auto;
            z-index: 10;
        }

        /* Cake Base */
        .cake {
            position: absolute;
            bottom: 0;
            left: 50%;
            transform: translateX(-50%);
            width: 200px;
            height: 120px;
            background: linear-gradient(to right, #ff85a2, #ff99b6);
            border-radius: 10px 10px 0 0;
            box-shadow: 0 5px 15px rgba(0, 0, 0, 0.2);
        }

        .cake:before {
            content: '';
            position: absolute;
            top: -40px;
            left: 0;
            width: 100%;
            height: 40px;
            background: linear-gradient(to right, #fc6c85, #ff85a2);
            border-radius: 10px 10px 0 0;
        }

        .cake:after {
            content: '';
            position: absolute;
            top: -70px;
            left: 10%;
            width: 80%;
            height: 30px;
            background: linear-gradient(to right, #ffb3c6, #ffcce6);
            border-radius: 10px 10px 0 0;
        }

        /* Frosting & Decorations */
        .frosting {
            position: absolute;
            top: -75px;
            left: 15%;
            width: 70%;
            height: 5px;
            background: #ffffff;
            border-radius: 5px;
            box-shadow: 0 0 5px #ffcce6;
        }

        .decoration {
            position: absolute;
            width: 10px;
            height: 10px;
            border-radius: 50%;
            background: #ff3366;
            box-shadow: 0 0 5px #ff99b6;
        }

        /* Candles */
        .candle-container {
            position: absolute;
            top: -95px;
            left: 0;
            width: 100%;
            display: flex;
            justify-content: center;
            gap: 20px;
            z-index: 15;
        }

        .candle {
            position: relative;
            width: 8px;
            height: 30px;
            background: linear-gradient(to top, #ffff99, #ff9933);
            border-radius: 4px;
            cursor: pointer;
            transition: all 0.3s ease;
        }

        .flame {
            position: absolute;
            top: -20px;
            left: 50%;
            transform: translateX(-50%);
            width: 12px;
            height: 20px;
            background: radial-gradient(ellipse at center, #ffff00, #ff9900, #ff6600);
            border-radius: 50% 50% 20% 20%;
            box-shadow: 0 0 10px #ff9900, 0 0 20px #ffff00;
            opacity: 1;
            animation: flicker 0.5s infinite alternate;
            z-index: 20;
        }

        @keyframes flicker {
            0% {
                transform: translateX(-50%) scale(1);
                opacity: 1;
            }
            100% {
                transform: translateX(-50%) scale(1.1);
                opacity: 0.9;
            }
        }

        .candle.blown .flame {
            opacity: 0;
            animation: none;
            transition: opacity 0.3s ease-out;
        }

        .smoke {
            position: absolute;
            top: -25px;
            left: 50%;
            transform: translateX(-50%);
            width: 8px;
            height: 0;
            background: rgba(200, 200, 200, 0.5);
            border-radius: 10px;
            opacity: 0;
            transition: all 0.5s ease;
        }

        .candle.blown .smoke {
            height: 30px;
            opacity: 0.7;
            animation: smokeRise 2s forwards;
        }

        @keyframes smokeRise {
            0% {
                height: 0;
                opacity: 0;
            }
            20% {
                height: 10px;
                opacity: 0.7;
            }
            100% {
                height: 30px;
                opacity: 0;
                transform: translateX(-50%) translateY(-30px) scale(1.5);
            }
        }

        /* Sparkles */
        .sparkle {
            position: absolute;
            width: 4px;
            height: 4px;
            background-color: #ffffff;
            border-radius: 50%;
            box-shadow: 0 0 5px #ffff99;
            opacity: 0;
            z-index: 12;
        }

        @keyframes sparkle {
            0% {
                transform: scale(0) rotate(0deg);
                opacity: 0;
            }
            50% {
                opacity: 1;
            }
            100% {
                transform: scale(1.5) rotate(90deg);
                opacity: 0;
            }
        }

        /* Enhanced Wish Message */
        .wish-message {
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%) scale(0);
            background: rgba(255, 255, 255, 0.95);
            padding: 25px;
            border-radius: 20px;
            box-shadow: 0 10px 30px rgba(255, 105, 180, 0.8), 
                        0 0 20px rgba(255, 255, 255, 0.8),
                        0 0 40px rgba(255, 51, 102, 0.4);
            text-align: center;
            z-index: 100;
            opacity: 0;
            width: 90%;
            max-width: 400px;
            transition: all 0.5s ease;
            border: 3px solid rgba(255, 255, 255, 0.7);
        }

        .wish-message.show {
            transform: translate(-50%, -50%) scale(1);
            opacity: 1;
            animation: bounceIn 0.8s;
        }

        @keyframes bounceIn {
            0% {
                transform: translate(-50%, -50%) scale(0);
                opacity: 0;
            }
            60% {
                transform: translate(-50%, -50%) scale(1.1);
                opacity: 1;
            }
            100% {
                transform: translate(-50%, -50%) scale(1);
                opacity: 1;
            }
        }

        .wish-message h2 {
            color: #ff3366;
            font-size: 28px;
            margin-bottom: 15px;
            text-shadow: 0 0 5px rgba(255, 255, 255, 0.7);
            background: linear-gradient(45deg, #ff3366, #ff66b3);
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            background-clip: text;
        }

        .wish-message p {
            color: #333;
            font-size: 20px;
            margin-bottom: 20px;
            line-height: 1.5;
            font-weight: 500;
        }

        /* Fireworks */
        .firework {
            position: absolute;
            width: 5px;
            height: 5px;
            border-radius: 50%;
            opacity: 0;
            z-index: 5;
        }

        @keyframes firework {
            0% {
                transform: scale(0);
                opacity: 1;
                box-shadow: 0 0 0 0px rgba(255, 255, 255, 0.9), 0 0 0 0px rgba(255, 0, 102, 0.9), 0 0 0 0px rgba(255, 255, 0, 0.9), 0 0 0 0px rgba(51, 204, 255, 0.9);
            }
            100% {
                transform: scale(1);
                opacity: 0;
                box-shadow: 0 0 0 50px rgba(255, 255, 255, 0), 0 0 0 100px rgba(255, 0, 102, 0), 0 0 0 150px rgba(255, 255, 0, 0), 0 0 0 200px rgba(51, 204, 255, 0);
            }
        }

        /* Navigation Buttons */
        .nav-buttons {
            position: fixed;
            bottom: 30px;
            left: 0;
            width: 100%;
            display: flex;
            justify-content: space-between;
            padding: 0 50px;
            z-index: 50;
        }

        .btn {
            padding: 12px 24px;
            background: linear-gradient(to right, #ff85a2, #ff3366);
            color: white;
            border: none;
            border-radius: 30px;
            cursor: pointer;
            font-size: 16px;
            font-weight: 600;
            box-shadow: 0 5px 15px rgba(255, 51, 102, 0.4);
            transition: all 0.3s ease;
            outline: none;
        }

        .btn:hover {
            transform: translateY(-3px);
            box-shadow: 0 8px 20px rgba(255, 51, 102, 0.6);
        }

        .btn:active {
            transform: translateY(-1px);
            box-shadow: 0 5px 10px rgba(255, 51, 102, 0.4);
        }

        /* Improved Responsive Design */
        @media (max-width: 768px) {
            .cake-container {
                width: 250px;
                height: 250px;
            }

            .cake {
                width: 160px;
                height: 90px;
            }

            .candle-container {
                gap: 15px;
            }

            .wish-message h2 {
                font-size: 24px;
            }

            .wish-message p {
                font-size: 18px;
            }

            .nav-buttons {
                padding: 0 20px;
                bottom: 20px;
            }
            
            .btn {
                padding: 10px 18px;
                font-size: 15px;
            }
        }

        @media (max-width: 480px) {
            .cake-container {
                width: 200px;
                height: 200px;
                margin: 10px auto;
            }

            .cake {
                width: 130px;
                height: 80px;
            }

            .candle-container {
                gap: 12px;
                top: -85px;
            }
            
            .candle {
                width: 6px;
                height: 25px;
            }

            .wish-message {
                width: 85%;
                padding: 20px;
            }
            
            .wish-message h2 {
                font-size: 22px;
                margin-bottom: 10px;
            }
            
            .wish-message p {
                font-size: 16px;
                margin-bottom: 15px;
            }

            .nav-buttons {
                padding: 0 15px;
                bottom: 15px;
            }

            .btn {
                padding: 8px 14px;
                font-size: 14px;
                white-space: nowrap;
            }
        }
        
        /* Extra small devices */
        @media (max-width: 360px) {
            .cake-container {
                width: 180px;
                height: 180px;
            }
            
            .cake {
                width: 110px;
                height: 70px;
            }
            
            .candle-container {
                gap: 10px;
            }
            
            .wish-message {
                width: 90%;
                padding: 15px;
            }
            
            .wish-message h2 {
                font-size: 20px;
            }
            
            .wish-message p {
                font-size: 14px;
            }
            
            .nav-buttons {
                flex-direction: column;
                align-items: center;
                gap: 10px;
            }
            
            .btn {
                width: 100%;
                text-align: center;
                font-size: 13px;
            }
        }
    </style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css">
</head>
<body>
    <!-- Balloons and Confetti will be added by JavaScript -->

    <!-- Birthday Cake -->
    <div class="cake-container">
        <div class="cake">
            <!-- Candles will be added by JavaScript -->
            <div class="candle-container" id="candleContainer"></div>
            
            <!-- Frosting & Decorations -->
            <div class="frosting"></div>
        </div>
    </div>

    <!-- Enhanced Wish Message Popup -->
    <div class="wish-message" id="wishMessage">
        <h2>✨ Happy Birthday! ✨</h2>
        <p>May your birthday be wonderful as you are Sri! May all your dreams come true! 🎂✨</p>
        <button class="btn" onclick="closeWishMessage()">Thank you! ❤️</button>
    </div>

    <!-- Navigation Buttons -->
    <div class="nav-buttons">
        <button class="btn" onclick="goBack()">◀ Back to Memory Lane</button>
        
    </div>

    <script>
        // Global variables
        let candlesBlown = 0;
        const totalCandles = 5;
        let allCandlesBlown = false;

        // Initialize the page when it loads
        document.addEventListener('DOMContentLoaded', function() {
            createCandles();
            createBalloons();
            createConfetti();
            createDecorations();
            
            // Add event listeners for candle interaction
            document.querySelectorAll('.candle').forEach(candle => {
                candle.addEventListener('click', blowOutCandle);
                candle.addEventListener('touchstart', blowOutCandle); // Better for mobile
                candle.addEventListener('mouseover', function(e) {
                    if (e.buttons === 0) { // Only trigger on hover when not clicking
                        blowOutCandle.call(this);
                    }
                });
            });
            
            // For better mobile experience with touch
            document.addEventListener('touchmove', function(e) {
                const touch = e.touches[0];
                const element = document.elementFromPoint(touch.clientX, touch.clientY);
                if (element && element.classList.contains('candle') && !element.classList.contains('blown')) {
                    blowOutCandle.call(element);
                }
            });
            
            // Optional: Listen for keyboard input 
            document.addEventListener('keypress', function(e) {
                if (e.key === 'b' || e.key === 'B') { // Press 'b' to simulate blowing
                    blowRandomCandle();
                }
            });
        });

        // Create candles for the cake
        function createCandles() {
            const candleContainer = document.getElementById('candleContainer');
            
            for (let i = 0; i < totalCandles; i++) {
                const candle = document.createElement('div');
                candle.className = 'candle';
                
                const flame = document.createElement('div');
                flame.className = 'flame';
                
                const smoke = document.createElement('div');
                smoke.className = 'smoke';
                
                candle.appendChild(flame);
                candle.appendChild(smoke);
                candleContainer.appendChild(candle);
            }
        }

        // Create floating balloons
        function createBalloons() {
            const colors = ['#ff66b3', '#66ccff', '#ff9966', '#99ff66', '#cc99ff'];
            const numBalloons = 15;
            
            for (let i = 0; i < numBalloons; i++) {
                const balloon = document.createElement('div');
                balloon.className = 'balloon';
                balloon.style.backgroundColor = colors[Math.floor(Math.random() * colors.length)];
                balloon.style.left = `${Math.random() * 100}%`;
                balloon.style.animationDuration = `${15 + Math.random() * 10}s`;
                balloon.style.animationDelay = `${Math.random() * 5}s`;
                document.body.appendChild(balloon);
            }
        }

        // Create confetti pieces
        function createConfetti() {
            const colors = ['#ffcc00', '#ff66b3', '#66ccff', '#ff9966', '#99ff66'];
            const numConfetti = 50;
            
            for (let i = 0; i < numConfetti; i++) {
                const confetti = document.createElement('div');
                confetti.className = 'confetti';
                confetti.style.backgroundColor = colors[Math.floor(Math.random() * colors.length)];
                confetti.style.left = `${Math.random() * 100}%`;
                confetti.style.width = `${5 + Math.random() * 5}px`;
                confetti.style.height = `${5 + Math.random() * 10}px`;
                confetti.style.animationDuration = `${3 + Math.random() * 4}s`;
                confetti.style.animationDelay = `${Math.random() * 5}s`;
                document.body.appendChild(confetti);
            }
        }

        // Create cake decorations
        function createDecorations() {
            const cake = document.querySelector('.cake');
            const colors = ['#ff3366', '#ffcc00', '#66ccff', '#ff9966', '#99ff66'];
            const numDecorations = 10;
            
            for (let i = 0; i < numDecorations; i++) {
                const decoration = document.createElement('div');
                decoration.className = 'decoration';
                decoration.style.backgroundColor = colors[Math.floor(Math.random() * colors.length)];
                decoration.style.top = `${-20 - Math.random() * 50}px`;
                decoration.style.left = `${Math.random() * 100}%`;
                cake.appendChild(decoration);
            }
        }

        // Blow out a candle when clicked or hovered
        function blowOutCandle() {
            if (!this.classList.contains('blown')) {
                this.classList.add('blown');
                candlesBlown++;
                
                // Create sparkle effect
                createSparkleEffect(this);
                
                // Check if all candles are blown
                if (candlesBlown === totalCandles && !allCandlesBlown) {
                    allCandlesBlown = true;
                    setTimeout(showWishMessage, 1000);
                }
            }
        }

        // Simulate blowing a random candle
        function blowRandomCandle() {
            const unblownCandles = Array.from(document.querySelectorAll('.candle:not(.blown)'));
            if (unblownCandles.length > 0) {
                const randomCandle = unblownCandles[Math.floor(Math.random() * unblownCandles.length)];
                blowOutCandle.call(randomCandle);
            }
        }

        // Create sparkle effect around the blown candle
        function createSparkleEffect(candle) {
            const numSparkles = 10;
            const candleRect = candle.getBoundingClientRect();
            
            for (let i = 0; i < numSparkles; i++) {
                const sparkle = document.createElement('div');
                sparkle.className = 'sparkle';
                sparkle.style.left = `${candleRect.left + Math.random() * candleRect.width}px`;
                sparkle.style.top = `${candleRect.top + Math.random() * (candleRect.height / 2)}px`;
                sparkle.style.animation = `sparkle ${0.5 + Math.random() * 0.5}s forwards`;
                document.body.appendChild(sparkle);
                
                // Remove sparkle after animation
                setTimeout(() => {
                    sparkle.remove();
                }, 1000);
            }
        }

        // Show the wish message when all candles are blown
        function showWishMessage() {
            document.getElementById('wishMessage').classList.add('show');
            createFireworks();
        }

        // Close the wish message
        function closeWishMessage() {
            document.getElementById('wishMessage').classList.remove('show');
        }

        // Create fireworks effect
        function createFireworks() {
            const numFireworks = 10;
            const colors = ['#ff3366', '#ffcc00', '#66ccff', '#ff9966', '#99ff66'];
            
            for (let i = 0; i < numFireworks; i++) {
                setTimeout(() => {
                    const firework = document.createElement('div');
                    firework.className = 'firework';
                    firework.style.left = `${10 + Math.random() * 80}%`;
                    firework.style.top = `${10 + Math.random() * 60}%`;
                    firework.style.backgroundColor = colors[Math.floor(Math.random() * colors.length)];
                    firework.style.animation = `firework ${1 + Math.random()}s forwards`;
                    document.body.appendChild(firework);
                    
                    // Remove firework after animation
                    setTimeout(() => {
                        firework.remove();
                    }, 2000);
                }, i * 300);
            }
        }

        // Navigation functions
        function goBack() {
            // Replace with actual back URL
           
             window.location.href = 'memorylane.html';
        }

        
    </script>
</body>
</html>
