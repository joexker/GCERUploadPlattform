import {reactive} from "vue";

export const video = reactive({
    visible: false,
    video: null,
    updateVideo(video) {
        this.visible = true;
        this.video = video;
    },
    close() {
        this.visible = false;
    },
    next() {
        this.video++;
    },
    prev() {
        if(this.video > 0)
            this.video--;
    }
})

export const addFile = reactive({
    visible: false,
    update() {
        this.visible = true;
    },
    close() {
        this.visible = false;
    },
    toggle() {
        this.visible = !this.visible;
    }
})

export const addDir = reactive({
    visible: false,
    update() {
        this.visible = true;
    },
    close() {
        this.visible = false;
    },
    toggle() {
        this.visible = !this.visible;
    }
})

export const addTeam = reactive({
    visible: false,
    update() {
        this.visible = true;
    },
    close() {
        this.visible = false;
    },
    toggle() {
        this.visible = !this.visible;
    }
})

export const currentTeamDir = reactive({
    teamId: null,
    directory: null,
    isTeam: true,
    switchTeamDir() {
        this.isTeam = !this.isTeam;
    },
    setToTeam() {
        this.isTeam = true;
    },
    setToDir() {
        this.isTeam = false;
    },
    updateDir(id) {
        this.directory = id;

    },
    updateTeam(id) {
        this.teamId = id;
    }
})
