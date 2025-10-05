// Lấy tất cả các phần tử có class 'faq-box'
const faqBoxes = document.querySelectorAll(".faq-box");

// Lặp qua từng phần tử và thêm sự kiện click
faqBoxes.forEach((faqBox) => {
  faqBox.addEventListener("click", () => {
    // Toggling class 'active' khi click vào faq-box
    faqBox.classList.toggle("active");
  });
});

// function initializeSlider(containerSelector) {
//   // Lấy tất cả các phần tử slide-item trong container
//   const slides = document.querySelectorAll(`${containerSelector} .slide-item`);
//   let currentIndex = 0;

//   // Hiển thị slide đầu tiên
//   slides[currentIndex].classList.add("active");

//   // Chức năng để hiển thị slide kế tiếp
//   function showNextSlide() {
//     slides[currentIndex].classList.remove("active"); // Ẩn slide hiện tại
//     currentIndex = (currentIndex + 1) % slides.length; // Tính chỉ số của slide kế tiếp
//     slides[currentIndex].classList.add("active"); // Hiển thị slide kế tiếp
//   }

//   // Chức năng để hiển thị slide trước
//   function showPrevSlide() {
//     slides[currentIndex].classList.remove("active"); // Ẩn slide hiện tại
//     currentIndex = (currentIndex - 1 + slides.length) % slides.length; // Tính chỉ số của slide trước
//     slides[currentIndex].classList.add("active"); // Hiển thị slide trước
//   }

//   // Lắng nghe sự kiện click cho các nút điều hướng
//   document
//     .querySelector(`${containerSelector} .next-slide`)
//     .addEventListener("click", showNextSlide);
//   document
//     .querySelector(`${containerSelector} .prev-slide`)
//     .addEventListener("click", showPrevSlide);
// }

// // Khởi tạo slider cho từng container
// initializeSlider(".slide");
// initializeSlider(".slide-v2");

// const swiper = new Swiper(".swiper", {
//   // Optional parameters
//   direction: "horizon",
//   loop: true,

//   // If we need pagination
//   pagination: {
//     el: ".swiper-pagination",
//   },

//   // Navigation arrows
//   navigation: {
//     nextEl: ".swiper-button-next",
//     prevEl: ".swiper-button-prev",
//   },

//   // And if we need scrollbar
//   scrollbar: {
//     el: ".swiper-scrollbar",
//   },
// });
const swiper = new Swiper(".swiper-container", {
  autoplay: {
    delay: 2000,
  },
  loop: true,
  navigation: {
    nextEl: ".next-slide",
    prevEl: ".prev-slide",
  },
});
const swiper1 = new Swiper(".swiper-container1", {
  autoplay: {
    delay: 2000,
  },
  loop: false,
  navigation: {
    nextEl: ".next-slide",
    prevEl: ".prev-slide",
  },
});
