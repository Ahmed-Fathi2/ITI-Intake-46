// let myPromise = new Promise((resolve, reject) => {
//     setTimeout(() => {
//         resolve("data success");
//         reject("failed data")
//     }, 1000)
// })

// myPromise.then((res) => {
//     console.log(res)
// })
//     .catch((e) => console.log(e))



function fetchData1() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("data 1 ");
            reject("error inside fetchData 1")
        }, 2000)
    })
}

function fetchData2(data1) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("data 2" + data1);
            reject("error inside fetchData 2")
        })
    })
}

function fetchData3(data2) {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("data3" + data2)
            reject("error inside fetchData 3")

        })
    })
}

fetchData1()
    .then(data1 => fetchData2(data1))
    .then(data2 => fetchData3(data2))
    .then(data3 => console.log(data3))
    .catch((e) => console.error(e))