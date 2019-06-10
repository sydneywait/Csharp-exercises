// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.querySelectorAll("input[type='checkbox']").forEach(checkbox => {
    checkbox.addEventListener("click", () => {

        const exerciseId = event.target.id.split("-")[1]
        const studentId = event.target.id.split("-")[2]
        const isComplete = event.target.checked
        const studentExercise = {exericiseId, studentId, isComplete}


        //fetch('/Students/')
    })
})

function markExerciseComplete(exerciseId){

    console.log("you checked the box");
    console.log(exerciseId);




}

function markExerciseIncomplete(studentId, exerciseId) {

    console.log("you unchecked the box");


}