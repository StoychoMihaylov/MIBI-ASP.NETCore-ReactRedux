import React, { Component } from 'react'
import { connect } from 'react-redux'
import { Route } from 'react-router'
import {
    getAllNamesOfExistingSamples,
    getAllExistingTagsFromServer,
    getAllExistingGroupsFromServer,
    fetchSamplesByGivenSearchParameters,
    fetchAllExistingNutrientAgarPlates
} from '../store/actions/SampleActions'
import "../styles/SearchSamples.css"

class SearchSampleView extends Component {
    constructor(props) {
        super(props)

        this.state = {
            showHideOptionSetOfNames: false,
            searchSampleName: "",
            optionSetNames: [],
            selectedNutrientAgarPlates: [],
            selectedTags: [],
            selectedGroups: [],
            isNutrientAgarPlateBtnClicked: false,
            isTagsBtnClicked: false,
            isGroupsBtnClicked: false
        }
    }

    async componentWillMount() {
        this.props.fetchAllNamesOfExistingSamples()
        this.props.fetchAllExistingTags()
        this.props.fetchAllExistingGroups()
        this.props.fetchAllNutrientAgarPlates()
    }

    setTheSelectedOption(event) {
        let value = event.target.value

        this.props.autocompleteNamesOfSamples.forEach(opt => {
            if(opt.name.toLowerCase() === value.toLowerCase()) {
                this.setState({
                    searchSampleName: value
                })

                this.setState({
                    showHideOptionSetOfNames: false
                })
            }
        })
    }

    hideOptionSetOfNames() {
        this.setState({
            showHideOptionSetOfNames: false
        })
    }

    showOptionSetOfNames(event) {
        let value = event.target.value
        let newOptSet = []

        // set value to the input
        this.setState({
            searchSampleName: value
        })

        // filter the option set values
        if(value.length > 0) {
            this.props.autocompleteNamesOfSamples.forEach(opt => {
                if(opt.name.toLowerCase().includes(value.toLowerCase())) {
                    newOptSet.push(opt)
                }
            })

            this.setState({
                optionSetNames: newOptSet,
                showHideOptionSetOfNames: true
            })
        } else {
            this.setState({
                showHideOptionSetOfNames: false
            })
        }
    }

    handleSearchBtnClickEvent() {
        let tagNames = []
        let groupNames = []
        let nutrientAgarPlateNames = []

        this.state.selectedTags.forEach((tag) => {
            tagNames.push(tag.name)
        })

        this.state.selectedGroups.forEach((group) => {
            groupNames.push(group.name)
        })

        this.state.selectedNutrientAgarPlates.forEach((nutrient) => {
            nutrientAgarPlateNames.push(nutrient.name)
        })

        let searchParameters = {
            bacteriaName: this.state.searchSampleName,
            tags: tagNames,
            groups: groupNames,
            nutrientAgarPlates: nutrientAgarPlateNames
        }

        this.props.fetchSamplesByGivenParameters(searchParameters)
    }

    addSearchingByTag(event) {
        let id = event.target.id
        let value = event.target.value.toLowerCase()
        let tabIndex = event.target.tabIndex
        let tags = this.state.selectedTags

        if(tabIndex === 0) {
            let element = document.getElementById(id)
            element.style.backgroundColor = "#66B2FF"
            element.tabIndex = "1"

            this.props.allExistingTags.forEach(tag => {
                if(tag.name.toLowerCase() === value) {
                    tags.push(tag)
                }
            })

            this.setState({
                selectedTags: tags
            })

        } else if (tabIndex === 1) {
            let element = document.getElementById(id)
            element.style.backgroundColor = "grey"
            element.tabIndex = "0"

            this.props.allExistingTags.forEach(tag => {
                if(tag.name.toLowerCase() === value) {
                    tags.splice(tags.findIndex(x => x.name === value), 1)
                }
            })

            this.setState({
                selectedTags: tags
            })
        }
    }

    addSearchingByGroup(event) {
        let id = event.target.id
        let value = event.target.value.toLowerCase()
        let tabIndex = event.target.tabIndex
        let groups = this.state.selectedGroups

        if(tabIndex === 0) {
            let element = document.getElementById(id)
            element.style.backgroundColor = "#66B2FF"
            element.tabIndex = "1"

            this.props.allExistingGroups.forEach(group => {
                if(group.name.toLowerCase() === value) {
                    groups.push(group)
                }
            })

            this.setState({
                selectedGroups: groups
            })

        } else if (tabIndex === 1) {
            let element = document.getElementById(id)
            element.style.backgroundColor = "grey"
            element.tabIndex = "0"

            this.props.allExistingGroups.forEach(group => {
                if(group.name.toLowerCase() === value) {
                    groups.splice(groups.findIndex(x => x.name === value), 1)
                }
            })

            this.setState({
                selectedGroups: groups
            })
        }
    }

    addSearchingByNutrientAgarPlate(event) {
        let id = event.target.id
        let value = event.target.value.toLowerCase()
        let tabIndex = event.target.tabIndex
        let nutrients = this.state.selectedNutrientAgarPlates

        if(tabIndex === 0) {
            let element = document.getElementById(id)
            element.style.backgroundColor = "#66B2FF"
            element.tabIndex = "1"

            this.props.allExistingNutrientAgarPlates.forEach(nutrient => {
                if(nutrient.name.toLowerCase() === value) {
                    nutrients.push(nutrient)
                }
            })

            this.setState({
                selectedNutrientAgarPlates: nutrients
            })

        } else if (tabIndex === 1) {
            let element = document.getElementById(id)
            element.style.backgroundColor = "grey"
            element.tabIndex = "0"

            this.props.allExistingNutrientAgarPlates.forEach(nutrient => {
                if(nutrient.name.toLowerCase() === value) {
                    nutrients.splice(nutrients.findIndex(x => x.name === value), 1)
                }
            })

            this.setState({
                selectedNutrientAgarPlates: nutrients
            })
        }
    }

    handleNutrientAgarPlatesBtnClick() {
        let state = this.state.isNutrientAgarPlateBtnClicked

        if(state) {
            this.setState({
                isNutrientAgarPlateBtnClicked: false,
                selectedNutrientAgarPlates: []
            })
        } else if(! state) {
            this.setState({
                isNutrientAgarPlateBtnClicked: true
            })
        }
    }

    handleGroupsBtnClick() {
        let state = this.state.isGroupsBtnClicked

        if(state) {
            this.setState({
                isGroupsBtnClicked: false,
                selectedGroups: []
            })
        } else if(! state) {
            this.setState({
                isGroupsBtnClicked: true
            })
        }
    }

    handleTagsBtnClick(){
        let state = this.state.isTagsBtnClicked

        if(state) {
            this.setState({
                isTagsBtnClicked: false,
                selectedTags: []
            })
        } else if(! state) {
            this.setState({
                isTagsBtnClicked: true
            })
        }
    }

    render() {
        let samples = this.props.samples.map((sample, index) => (
            <Route render={({ history }) => (
                <div key={index} id={sample.id} className="sampleResult" onClick={() => history.push('/sample/' + sample.id)}>
                    <div className="sampleTitle"><div className="title">{sample.name}</div></div>
                    <img className="sampleImg" src={'https://localhost:44376/Images/' + sample.images[0].url} alt="sample" />
                    <div className="sampleFooter"><div className="footerDate">Created on: {sample.createdOn.split("T")[0]}</div></div>
                </div>
             )} />
        ))

        let optionSetOfNames = this.state.optionSetNames.map((rec, index) => {
            return (
                <div key={index}>
                    <input
                        className="optionNames"
                        type="text"
                        value={rec.name}
                        onClick={this.setTheSelectedOption.bind(this)}
                    />
                </div>
            )
        })

        let nutrientAgarPlates = this.props.allExistingNutrientAgarPlates.map((nutrient, index) => {
            return (
                <button
                    key={index}
                    id={nutrient.id}
                    tabIndex="0"
                    className="nutrients"
                    value={nutrient.name}
                    onClick={this.addSearchingByNutrientAgarPlate.bind(this)}
                    >{nutrient.name}
                </button>
            )
        })

        let tagsCategoryColors = this.props.allExistingTags.map((tag, index) => {
            if(tag.category === "Colors") {
                return (
                    <button
                        key={index}
                        id={tag.id}
                        className="tags"
                        tabIndex="0"
                        type="text"
                        value={tag.name}
                        onClick={this.addSearchingByTag.bind(this)}
                        >{tag.name}
                        <span className="tagColor" style={{backgroundColor: tag.color}}>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                    </button>
                )
            }
        })

        let tagsCategoryConsistency = this.props.allExistingTags.map((tag, index) => {
            if(tag.category === "Consistency") {
                return (
                    <button
                        key={index}
                        id={tag.id}
                        className="tags"
                        tabIndex="0"
                        type="text"
                        value={tag.name}
                        onClick={this.addSearchingByTag.bind(this)}
                        >{tag.name}
                    </button>
                )
            }
        })

        let tagsCategorySurfaceAppearance = this.props.allExistingTags.map((tag, index) => {
            if(tag.category === "Surface appearance") {
                return (
                    <button
                        key={index}
                        id={tag.id}
                        className="tags"
                        tabIndex="0"
                        type="text"
                        value={tag.name}
                        onClick={this.addSearchingByTag.bind(this)}
                        >{tag.name}
                    </button>
                )
            }
        })

        let tagsCategoryForm = this.props.allExistingTags.map((tag, index) => {
            if(tag.category === "Form") {
                return (
                    <button
                        key={index}
                        id={tag.id}
                        className="tags"
                        tabIndex="0"
                        type="text"
                        value={tag.name}
                        onClick={this.addSearchingByTag.bind(this)}
                        >{tag.name}
                        <img src={require('../content/tagIcons/' + tag.iconUrl)} className="tagIcon"/>
                    </button>
                )
            }
        })

        let tagsCategoryElevations = this.props.allExistingTags.map((tag, index) => {
            if(tag.category === "Elevations") {
                return (
                    <button
                        key={index}
                        id={tag.id}
                        className="tags"
                        tabIndex="0"
                        type="text"
                        value={tag.name}
                        onClick={this.addSearchingByTag.bind(this)}
                        >{tag.name}
                        <img src={require('../content/tagIcons/' + tag.iconUrl)} className="tagIcon"/>
                    </button>
                )
            }
        })

        let groups = this.props.allExistingGroups.map((grop, index) => (
            <button
                key={index}
                id={grop.id}
                className="groups"
                tabIndex="0"
                type="text"
                value={grop.name}
                onClick={this.addSearchingByGroup.bind(this)}
                >
                {grop.name}
            </button>
        ))

    return(
        <div className="conteiner">
            <div className="searchingBar">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <input
                                    id="searchInput"
                                    placeholder="Search..."
                                    value={this.state.searchSampleName}
                                    onChange={this.showOptionSetOfNames.bind(this)}
                                    onBlur={() => setTimeout(this.hideOptionSetOfNames.bind(this), 100)} // When optionSetOfNames is clicked it takes time to sate the name chosen name
                                />
                                {
                                    this.state.showHideOptionSetOfNames
                                    ?
                                    <div id="autocompleateListOfNames">
                                        {optionSetOfNames}
                                    </div>
                                    :
                                    ""
                                }
                            </td>
                            <td>
                                <button
                                    id="searchBtn"
                                    onClick={this.handleSearchBtnClickEvent.bind(this)}
                                    >
                                        <img alt=""/>
                                </button>
                            </td>
                            <td>
                                <Route render={({ history }) => (
                                    <button
                                        id="addSampleBtn"
                                        type='button'
                                        onClick={() => { history.push('/addSample') }}
                                        >Add Sample
                                    </button>
                                )} />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div>
                    {
                        this.state.isGroupsBtnClicked
                        ?
                        <div className="groupsContainer">
                            <button
                                id="groupsTitle"
                                onClick={this.handleGroupsBtnClick.bind(this)}
                                >Groups
                            </button>
                            <br/>
                            { groups }
                        </div>
                        :
                        <button
                            id="groupsBtn"
                            onClick={this.handleGroupsBtnClick.bind(this)}
                            >Groups
                        </button>
                    }
                    {
                        this.state.isNutrientAgarPlateBtnClicked
                        ?
                        <div className="nutrientAgarPlatesContainer">
                            <button
                                id="nutriensTitle"
                                onClick={this.handleNutrientAgarPlatesBtnClick.bind(this)}
                                >Nutrient Agar Plates
                            </button>
                            <br/>
                            { nutrientAgarPlates }
                        </div>
                        :
                        <button
                            id="nutriensBtn"
                            onClick={this.handleNutrientAgarPlatesBtnClick.bind(this)}
                            >Nutrient Agar Plates
                        </button>
                    }
                    {
                        this.state.isTagsBtnClicked
                        ?
                        <div className="tagsConteiner">
                            <button
                                id="tagsTitle"
                                onClick={this.handleTagsBtnClick.bind(this)}
                                >Tags
                            </button>
                            <br/>
                            <h4>Elevations</h4>
                            { tagsCategoryElevations }
                            <hr/>
                            <h4>Form</h4>
                            { tagsCategoryForm }
                            <hr/>
                            <h4>Surface appearance</h4>
                            { tagsCategorySurfaceAppearance }
                            <hr/>
                            <h4>Consistency</h4>
                            { tagsCategoryConsistency }
                            <hr/>
                            <h4>Colors</h4>
                            { tagsCategoryColors }
                        </div>
                        :
                        <button
                            id="tagsBtn"
                            onClick={this.handleTagsBtnClick.bind(this)}
                            >Tags
                        </button>
                    }
                </div>
            </div>
            { samples }
        </div>
        )
    }
}

const mapStateToProps = state => {
    return {
        samples: state.sample.samples,
        allExistingNutrientAgarPlates: state.sample.allExistingNutrientAgarPlates,
        allExistingGroups: state.sample.allExistingGroups,
        allExistingTags: state.sample.allExistingTags,
        autocompleteNamesOfSamples: state.sample.autocompleteNamesOfSamples,
        isLoading: state.sample.isLoading,
        error: state.sample.error
    }
}

const mapDispatchToProps = dispatch => {
    return {
        fetchSamplesByGivenParameters: (params) => dispatch(fetchSamplesByGivenSearchParameters(params)),
        fetchAllNamesOfExistingSamples: () => dispatch(getAllNamesOfExistingSamples()),
        fetchAllExistingTags: () => dispatch(getAllExistingTagsFromServer()),
        fetchAllExistingGroups: () => dispatch(getAllExistingGroupsFromServer()),
        fetchAllNutrientAgarPlates: () => dispatch(fetchAllExistingNutrientAgarPlates())
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(SearchSampleView)
