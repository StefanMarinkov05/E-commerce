const dynamicStars = document.getElementById('dynamicStars');
let css = '';

for (let i = 1; i <= 50; i++) {
    const width = i * 2;

    css += `
                [data-star^="${i / 10}"]::after {
                    width: ${width}%;
                }
            `;
}

dynamicStars.textContent = css;
