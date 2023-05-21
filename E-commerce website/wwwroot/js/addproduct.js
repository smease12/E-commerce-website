discount.addEventListener('input', () => {
    if (discount.value > 100) {
        discount.value = 90;
    } else {
        let d = (actualprice.value * discount.value) / 100;
        sellprice.value = actualprice.value - d;
        
    }
})

sellprice.addEventListener('input', () => {
    let d = (sellprice.value / actualprice.value) * 100;
    discount.value = d;
})
