document.addEventListener("DOMContentLoaded", () => {
	console.clear();

	const { gsap, imagesLoaded } = window;

	const buttons = {
		prev: document.querySelector(".btn--left"),
		next: document.querySelector(".btn--right"),
	};


	const cardsContainerEl = document.querySelector(".cards__wrapper");
	const appBgContainerEl = document.querySelector(".app__bg");

	const cardInfosContainerEl = document.querySelector(".info__wrapper");

	buttons.next.addEventListener("click", () => swapCards("right"));
	document.addEventListener('keydown', function (event) {
		if (event.key === 'ArrowRight') {
			swapCards("right");
		}
	});


	buttons.prev.addEventListener("click", () => swapCards("left"));
	document.addEventListener('keydown', function (event) {
		if (event.key === 'ArrowLeft') {
			swapCards("left");
		}
	});

	buttons.next.click();

	function swapCards(direction) {
		const currentCardEl = cardsContainerEl.querySelector(".current--card");
		const previousCardEl = cardsContainerEl.querySelector(".previous--card");
		const nextCardEl = cardsContainerEl.querySelector(".next--card");

		const currentBgImageEl = appBgContainerEl.querySelector(".current--image");
		const previousBgImageEl = appBgContainerEl.querySelector(".previous--image");
		const nextBgImageEl = appBgContainerEl.querySelector(".next--image");

		changeInfo(direction);
		swapCardsClass();

		removeCardEvents(currentCardEl);

		function swapCardsClass() {
			currentCardEl.classList.remove("current--card");
			previousCardEl.classList.remove("previous--card");
			nextCardEl.classList.remove("next--card");

			currentBgImageEl.classList.remove("current--image");
			previousBgImageEl.classList.remove("previous--image");
			nextBgImageEl.classList.remove("next--image");

			currentCardEl.style.zIndex = "50";
			currentBgImageEl.style.zIndex = "-2";

			if (direction === "right") {
				previousCardEl.style.zIndex = "20";
				nextCardEl.style.zIndex = "30";

				nextBgImageEl.style.zIndex = "-1";

				currentCardEl.classList.add("previous--card");
				previousCardEl.classList.add("next--card");
				nextCardEl.classList.add("current--card");

				currentBgImageEl.classList.add("previous--image");
				previousBgImageEl.classList.add("next--image");
				nextBgImageEl.classList.add("current--image");


				currentCardEl.style.filter = "brightness(20%)";
				previousCardEl.style.filter = "brightness(20%)";
				nextCardEl.style.filter = "brightness(100%)";
			} else if (direction === "left") {
				previousCardEl.style.zIndex = "30";
				nextCardEl.style.zIndex = "20";

				previousBgImageEl.style.zIndex = "-1";

				currentCardEl.classList.add("next--card");
				previousCardEl.classList.add("current--card");
				nextCardEl.classList.add("previous--card");

				currentBgImageEl.classList.add("next--image");
				previousBgImageEl.classList.add("current--image");
				nextBgImageEl.classList.add("previous--image");


				currentCardEl.style.filter = "brightness(20%)";
				previousCardEl.style.filter = "brightness(100%)";
				nextCardEl.style.filter = "brightness(20%)";
			}

		}
	}

	function changeInfo(direction) {
		let currentInfoEl = cardInfosContainerEl.querySelector(".current--info");
		let previousInfoEl = cardInfosContainerEl.querySelector(".previous--info");
		let nextInfoEl = cardInfosContainerEl.querySelector(".next--info");

		gsap.timeline()
			.to([buttons.prev, buttons.next], {
				duration: 0.2,
				opacity: 0.5,
				pointerEvents: "none",
			})
			.to(
				currentInfoEl.querySelectorAll(".text"),
				{
					duration: 0.4,
					stagger: 0.1,
					translateY: "-120px",
					opacity: 0,
				},
				"-="
			)
			.call(() => {
				swapInfosClass(direction);
			})
			.call(() => initCardEvents())
			.fromTo(
				direction === "right"
					? nextInfoEl.querySelectorAll(".text")
					: previousInfoEl.querySelectorAll(".text"),
				{
					opacity: 0,
					translateY: "40px",
				},
				{
					duration: 0.4,
					stagger: 0.1,
					translateY: "0px",
					opacity: 1,
				}
			)
			.to([buttons.prev, buttons.next], {
				duration: 0.2,
				opacity: 1,
				pointerEvents: "all",
			});

		function swapInfosClass() {
			currentInfoEl.classList.remove("current--info");
			previousInfoEl.classList.remove("previous--info");
			nextInfoEl.classList.remove("next--info");

			if (direction === "right") {
				currentInfoEl.classList.add("previous--info");
				nextInfoEl.classList.add("current--info");
				previousInfoEl.classList.add("next--info");
			} else if (direction === "left") {
				currentInfoEl.classList.add("next--info");
				nextInfoEl.classList.add("previous--info");
				previousInfoEl.classList.add("current--info");
			}
		}
	}

	function init() {

		let tl = gsap.timeline();

		tl.to(cardsContainerEl.children, {
			delay: 0.15,
			duration: 0.5,
			stagger: {
				ease: "power4.inOut",
				from: "right",
				amount: 0.1,
			},
			"--card-translateY-offset": "0%",
		})
			.to(cardInfosContainerEl.querySelector(".current--info").querySelectorAll(".text"), {
				delay: 0.5,
				duration: 0.4,
				stagger: 0.1,
				opacity: 1,
				translateY: 0,
			})
			.to(
				[buttons.prev, buttons.next],
				{
					duration: 0.4,
					opacity: 1,
					pointerEvents: "all",
				},
				"-=0.4"
			);
	}

	const waitForImages = () => {
		const images = [...document.querySelectorAll("img")];
		const totalImages = images.length;
		let loadedImages = 0;
		const loaderEl = document.querySelector(".loader span");

		gsap.set(cardsContainerEl.children, {
			"--card-translateY-offset": "100vh",
		});
		gsap.set(cardInfosContainerEl.querySelector(".current--info").querySelectorAll(".text"), {
			translateY: "40px",
			opacity: 0,
		});
		gsap.set([buttons.prev, buttons.next], {
			pointerEvents: "none",
			opacity: "0",
		});

		images.forEach((image) => {
			imagesLoaded(image, (instance) => {
				if (instance.isComplete) {
					loadedImages++;
					let loadProgress = loadedImages / totalImages;

					gsap.to(loaderEl, {
						duration: 1,
						scaleX: loadProgress,
						backgroundColor: `hsl(${loadProgress * 120}, 100%, 50%`,
					});

					if (totalImages == loadedImages) {
						gsap.timeline()
							.to(".loading__wrapper", {
								duration: 0.8,
								opacity: 0,
								pointerEvents: "none",
							})
							.call(() => init());
					}
				}
			});
		});
	};

	waitForImages();

});

document.addEventListener("DOMContentLoaded", function () {
	var descriptions = document.querySelectorAll('.description');
	descriptions.forEach(function (description) {
		var words = description.textContent.split(' ');
		if (words.length >= 4) {
			var firstLine = words.slice(0, 4).join(' ');
			var remainingWords = words.slice(4).join(' ');
			description.innerHTML = firstLine + '<br>' + remainingWords;
		}
	});
});