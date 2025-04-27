document.querySelectorAll('.btn-format').forEach(btn => {
    btn.addEventListener('click', function () {
        const format = this.dataset.format;
        const textarea = document.querySelector('.editor-content');
        const start = textarea.selectionStart;
        const end = textarea.selectionEnd;
        const selectedText = textarea.value.substring(start, end);

        const formats = {
            bold: ['**', '**'],
            italic: ['_', '_'],
            link: ['[نص الرابط](', ')']
        };

        textarea.value =
            textarea.value.substring(0, start) +
            formats[format][0] + selectedText + formats[format][1] +
            textarea.value.substring(end);
    });
});
// بيانات نموذجية
const data = {
    students: [
        {
            STU_ID: '2023001',
            STU_NAME: 'محمد أحمد',
            STU_YEAR: 'الثانية',
            STU_STATE: 'ناجح'
        },
        // ... بيانات أخرى
    ],
    posts: [],
    projects: []
};

// وظائف إدارة الجداول
function renderTable(tableId, data) {
    const tbody = document.getElementById(tableId);
    tbody.innerHTML = data.map(item => `
            <tr>
                <td>${item.STU_ID}</td>
                <td>${item.STU_NAME}</td>
                <td>${item.STU_YEAR}</td>
                <td>${item.STU_STATE}</td>
                <td>
                    <button class="btn btn-primary">تعديل</button>
                    <button class="btn btn-danger">حذف</button>
                </td>
            </tr>
        `).join('');
}

// إدارة التبويبات
document.querySelectorAll('.nav-tabs li').forEach(tab => {
    tab.addEventListener('click', () => {
        document.querySelectorAll('.tab-pane').forEach(pane => {
            pane.classList.remove('active');
        });
        document.getElementById(tab.dataset.tab).classList.add('active');
    });
});

// وظائف النماذج
function showForm(type) {
    document.getElementById(`${type}Modal`).style.display = 'block';
}

function closeModal(type) {
    document.getElementById(`${type}Modal`).style.display = 'none';
}


// التهيئة الأولية
window.onload = () => {
    renderTable('studentTable', data.students);
    // يمكن استدعاء بقية الجداول هنا
};



const fullData = {
    subjects: [
        {
            SUB_ID: 'CS101',
            SUB_NAME: 'برمجة شيئية',
            SUB_TYPE: 'إجبارية',
            SUB_YEAR: 'الأولى',
            SUB_SEMESTER: 'الثاني'
        }
    ],
    lectures: [
        {
            LEC_ID: 'LEC001',
            LEC_TITLE: 'مقدمة في الجافا',
            LEC_TYPE: 'نظري',
            LEC_DATE: '2023-10-01'
        }
    ],
    quizzes: [
        {
            QU_ID: 'Q001',
            QU_TEXT: 'ما هي خاصية الوراثة في البرمجة؟',
            RIGHT_ANSR: 'الإجابة الثالثة'
        }
    ],
    classes: [
        {
            CLS_ID: 'LAB-201',
            ATTENDANCE_FILE: 'attendance_2023.csv'
        }
    ],
    admins: [
        {
            ADM_ID: 'ADM001',
            ADM_NAME: 'د. أحمد محمد',
            ADM_PERMISSION: 'كامل الصلاحيات'
        }
    ]
};

// وظائف عرض الجداول
function renderSubjectTable() {
    const tbody = document.getElementById('subjectTable');
    tbody.innerHTML = fullData.subjects.map(sub => `
            <tr>
                <td>${sub.SUB_ID}</td>
                <td>${sub.SUB_NAME}</td>
                <td>${sub.SUB_TYPE}</td>
                <td>${sub.SUB_YEAR}</td>
                <td>${sub.SUB_SEMESTER}</td>
                <td>${sub.DOC_ID || 'غير معين'}</td>
                <td>
                    <button class="btn btn-primary">تعديل</button>
                    <button class="btn btn-danger">حذف</button>
                </td>
            </tr>
        `).join('');
}

// تهيئة جميع الجداول
window.onload = () => {
    renderTable('studentTable', fullData.students);
    renderSubjectTable();
    // إضافة استدعاءات لباقي الجداول
    renderTable('adminTable', fullData.admins);
    renderTable('classTable', fullData.classes);
    renderTable('quizTable', fullData.quizzes);
    renderTable('lectureTable', fullData.lectures);
};





// مثال لعلاقة بين الجداول
function linkStudentProject() {
    fullData.projects.forEach(pro => {
        pro.students = fullData.students.filter(
            stu => stu.PRO_ID === pro.PRO_ID
        );
    });
}



function closeModal(modalName) {
    document.getElementById(`${modalName}Modal`).style.display = "none";
}

function openModal(modalName) {
    document.getElementById(`${modalName}Modal`).style.display = "block";
}

function showStudentDetails(student) {
    document.getElementById("view_name").innerText = student.name;
    document.getElementById("view_father").innerText = student.father;
    document.getElementById("view_mother").innerText = student.mother;
    document.getElementById("view_birth").innerText = student.birth;
    document.getElementById("view_join").innerText = student.join;
    document.getElementById("view_year").innerText = student.year;
    document.getElementById("view_state").innerText = student.state;
    document.getElementById("view_nationality").innerText = student.nationality;
    document.getElementById("view_bac_avg").innerText = student.bac_avg;
    document.getElementById("view_compar").innerText = student.compar_type;
    document.getElementById("view_cls").innerText = student.cls_id;

    openModal("viewStudent");
}

function showDeleteStudentModal(studentId, studentName) {
    document.getElementById("delete_student_name").innerText = studentName;
    window.currentDeleteId = studentId;
    openModal("deleteStudent");
}

function confirmDeleteStudent() {
    const id = window.currentDeleteId;
    // نفذ عملية الحذف باستخدام AJAX أو طريقة أخرى
    console.log("حذف الطالب ذو المعرف: ", id);
    closeModal("deleteStudent");
}

function showEditStudentModal(student) {
    document.getElementById("edit_id").value = student.id;
    document.getElementById("edit_name").value = student.name;
    // أكمل باقي الحقول...

    openModal("editStudent");
}




function loadHTML(id, file) {
    fetch(file)
        .then(response => response.text())
        .then(data => {
            document.getElementById(id).innerHTML = data;
        });
}
loadHTML("postmodal", "/modals/postmodal.html");
//student models
loadHTML("studentmodal", "/modals/studentmodal.html");

loadHTML("studentdetailsmodal", "/modals/studentdetailsmodal.html");
loadHTML("editstudentmodal", "/modals/editstudentmodal.html");
loadHTML("confirmdeletemodal", "/modals/confirmdeletemodal.html");


loadHTML("projectmodal", "/modals/projectmodal.html");
loadHTML("adminmodal", "/modals/adminmodal.html");
loadHTML("subjectmodal", "/modals/subjectmodal.html");
loadHTML("lecturemodal", "/modals/lecturemodel.html");
loadHTML("quizmodal", "/modals/quizmodal.html");
loadHTML("classmodal", "/modals/classmodal.html");


loadHTML("sidebar", "/layouts/sidebar.html");







// التحكم في القائمة الجانبية
const sidebar = document.querySelector('.sidebar');
const toggleBtn = document.querySelector('.sidebar-toggle');

toggleBtn.addEventListener('click', () => {
    sidebar.classList.toggle('active');
});

// إغلاق القائمة عند النقر خارجها
document.addEventListener('click', (e) => {
    if (!sidebar.contains(e.target) && !toggleBtn.contains(e.target)) {
        sidebar.classList.remove('active');
    }
});

// إغلاق القائمة عند تغيير حجم الشاشة
window.addEventListener('resize', () => {
    if (window.innerWidth > 768) {
        sidebar.classList.remove('active');
    }
});







